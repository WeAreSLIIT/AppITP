using Models.Core;
using Styles.Controler;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using WPF.Views.ApplicationContent.InvoiceContents;
using ModelViews = WPF.ModelView.ApplicationContent;

namespace WPF.Views.ApplicationContent
{
    /// <summary>
    /// Interaction logic for InvoiceContent.xaml
    /// </summary>
    public partial class InvoiceContent : UserControl
    {
        #region Notify Property Changed

        //public event PropertyChangedEventHandler PropertyChanged;

        //public void NotifyPropertyChanged(string propName)
        //{
        //    if (this.PropertyChanged != null)
        //        this.PropertyChanged(this, new PropertyChangedEventArgs(propName));
        //}

        #endregion

        //Content Pages
        private SearchProductContent _productContent;
        private SearchCustomerContent _customerContent;
        private SearchPaymentMethodContent _paymentMethodContent;

        private Timer _checkQuantityIsCorrectTimer;

        private ModelViews.InvoiceContent _invoiceData;

        private byte _invoiceContentCurrentPage;

        public InvoiceContentCurrentPage ContentCurrentPage
        {
            get { return (InvoiceContentCurrentPage)this._invoiceContentCurrentPage; }
            set
            {
                this._invoiceContentCurrentPage = (byte)value;

                if (value == InvoiceContentCurrentPage.Invoices)
                {
                    this.ContentPanel.Visibility = Visibility.Collapsed;
                    this.ContentPanelContent.Content = null;
                }
                else if (value == InvoiceContentCurrentPage.Product)
                {
                    this.ContentPanel.Visibility = Visibility.Visible;
                    this.ContentPanelContent.Content = this._productContent;
                }
                else if (value == InvoiceContentCurrentPage.PaymentMethod)
                {
                    this.ContentPanel.Visibility = Visibility.Visible;
                    this.ContentPanelContent.Content = this._paymentMethodContent;
                }
                else if (value == InvoiceContentCurrentPage.Customer)
                {
                    this.ContentPanel.Visibility = Visibility.Visible;
                    this.ContentPanelContent.Content = this._customerContent;
                }
            }
        }

        public InvoiceContent()
        {
            this._invoiceData = new ModelViews.InvoiceContent();
            
            this._productContent = new SearchProductContent(this);
            this._customerContent = new SearchCustomerContent(this);
            this._paymentMethodContent = new SearchPaymentMethodContent(this);

            InitializeComponent();

            //databindings
            InvoiceItemsList.ItemsSource = this._invoiceData.ProductsList;

            GrossTotalTextBlock.SetBinding(TextBlock.TextProperty,
                new Binding()
                {
                    Source = this._invoiceData,
                    Path = new PropertyPath("GrossTotal"),
                    Delay = 500
                });

            InvoiceDiscountTextBlock.SetBinding(TextBlock.TextProperty,
                new Binding()
                {
                    Source = this._invoiceData,
                    Path = new PropertyPath("Discount"),
                    Delay = 500
                });

            NetTotalTextBlock.SetBinding(TextBlock.TextProperty,
                new Binding()
                {
                    Source = this._invoiceData,
                    Path = new PropertyPath("NetTotal"),
                    Delay = 500
                });

            this._checkQuantityIsCorrectTimer = new Timer();
            this._checkQuantityIsCorrectTimer.Elapsed += (s, e) => { try { this.RefreshQuantityInInvoice(); } catch { } };
            this._checkQuantityIsCorrectTimer.Interval = 0.5 * 1000;
            this._checkQuantityIsCorrectTimer.Enabled = true;

            ContentCurrentPage = InvoiceContentCurrentPage.Invoices;
        }

        private void RefreshQuantityInInvoice()
        {
            if (!(this._invoiceData.ProductsList == null || this._invoiceData.ProductsList.Count == 0))
            {
                bool isAllOk = true;
                float tot = 0F, dis = 0F;

                float.TryParse(this._invoiceData.Discount, out dis);

                foreach (InvoiceItemContent Item in this._invoiceData.ProductsList)
                {
                    int index = this._invoiceData.ProductsList.IndexOf(Item);
                    Item.Dispatcher.Invoke(() => { Item.ItemNo = index + 1; });

                    float itemPrice;

                    //Accessing UI threads controler
                    string totPriceItem = Item.Dispatcher.Invoke(() => { return Item.TotalPrice; });

                    if (float.TryParse(totPriceItem, out itemPrice))
                    {
                        tot += itemPrice;
                        isAllOk = true;
                    }
                    else
                        isAllOk = false;

                    if (!isAllOk)
                        break;
                }

                if (isAllOk)
                {
                    this._invoiceData.NetTotal = string.Format("{0:0.00}", tot - dis);
                    this._invoiceData.GrossTotal = string.Format("{0:0.00}", tot);
                    this._invoiceData.Discount = string.Format("{0:0.00}", dis);
                }
                else
                {
                    this._invoiceData.NetTotal = "--.--";
                    this._invoiceData.GrossTotal = "--.--";
                    this._invoiceData.Discount = "--.--";
                }
            }
            else
            {
                this._invoiceData.NetTotal = "--.--";
                this._invoiceData.GrossTotal = "--.--";
                this._invoiceData.Discount = "--.--";
            }
        }

        private void RemoveProduct_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            if (InvoiceItemsList.SelectedItem != null)
            {
                this._invoiceData.ProductsList.RemoveAt((InvoiceItemsList.SelectedIndex));
            }
        }

        private void SearchProduct_Click(object sender, RoutedEventArgs e)
        {
            ContentCurrentPage = InvoiceContentCurrentPage.Product;
        }

        public void AddProductToProductList(Product Product)
        {
            InvoiceItemContent IIC = this._invoiceData.ProductsList.SingleOrDefault(pl => pl.ProductID == Product.ID);

            if (IIC == null)
            {
                this._invoiceData.ProductsList.Add(new InvoiceItemContent()
                {
                    ItemNo = this._invoiceData.ProductsList.Count + 1,
                    ItemPrice = Product.Price.ToString(),
                    ProductID = Product.ID,
                    ProductDescription = Product.Name,
                    ItemType = Product.Type == Models.Core.ProductType.Measurable ? Styles.Controler.ProductType.Measurable : Styles.Controler.ProductType.Unit,
                    Quantity = Product.Type == Models.Core.ProductType.Measurable ? "1.000" : "1",
                    AllSettedUp = true
                });

                InvoiceItemsList.SelectedIndex = this._invoiceData.ProductsList.Count - 1;
                InvoiceItemsList.ScrollIntoView(InvoiceItemsList.SelectedItem);
                InvoiceItemsList.SelectedIndex = -1;
            }
            else
            {
                int itemIndex = IIC.ItemNo - 1;
                InvoiceItemsList.SelectedIndex = itemIndex;
                InvoiceItemsList.ScrollIntoView(InvoiceItemsList.SelectedItem);
            }
        }

        private void InvoiceItemsList_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == Key.Delete)
                RemoveProduct_Click(null, null);
        }

        private void SearchCustomer_Click(object sender, RoutedEventArgs e)
        {
            this.ContentCurrentPage = InvoiceContentCurrentPage.Customer;
        }

        private void SearchPaymentMethod_Click(object sender, RoutedEventArgs e)
        {
            this.ContentCurrentPage = InvoiceContentCurrentPage.PaymentMethod;
        }

        private void ContentPanelBackground_MouseUp(object sender, MouseButtonEventArgs e)
        {
            this.ContentCurrentPage = InvoiceContentCurrentPage.Invoices;
        }
    }

    public enum InvoiceContentCurrentPage
    {
        Invoices = 0,
        Product,
        PaymentMethod,
        Customer
    }
}
