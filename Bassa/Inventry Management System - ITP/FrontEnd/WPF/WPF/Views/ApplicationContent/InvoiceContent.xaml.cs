using Styles.Controler;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using WPFs = WPF.ModelView.ApplicationContent;

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

        private ObservableCollection<InvoiceItemContent> _invoiceProducts;
        private Timer _checkQuantityIsCorrectTimer;

        private WPFs.InvoiceContent _invoiceData;

        public InvoiceContent()
        {
            this._invoiceData = new WPFs.InvoiceContent();
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
            this._invoiceData.ProductsList.Add(new InvoiceItemContent()
            {
                ItemNo = this._invoiceData.ProductsList.Count + 1,
                ItemPrice = "100.00",
                ProductID = "Bic-01-01",
                ProductDescription = "Gold Maree",
                Quantity = "1",
                ItemType = ProductType.Unit,
                AllSettedUp = true
            });
        }

        private void InvoiceItemsList_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == Key.Delete)
                RemoveProduct_Click(null, null);
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
