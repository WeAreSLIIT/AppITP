using Models.APICall;
using Models.APICall.Resources;
using Models.Core;
using Styles.Controler;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
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

        //
        private ApplicationContentView _applicationContentView;

        //Primary Content Page
        private ModelViews.InvoiceContent _invoiceData;

        #region Content Pages

        //Content Pages
        private SearchProductContent _productContent;
        private SearchCustomerContent _customerContent;
        private SearchPaymentMethodContent _paymentMethodContent;

        public void ResetSearchProductContent()
        {
            this._productContent = new SearchProductContent(this);
        }

        public void ResetSearchCustomerContent()
        {
            this._customerContent = new SearchCustomerContent(this);
        }

        public void ResetSearchPaymentMethodContent()
        {
            this._paymentMethodContent = new SearchPaymentMethodContent(this);
        }

        public void ResetAllContentPages()
        {
            this.ResetSearchProductContent();
            this.ResetSearchCustomerContent();
            this.ResetSearchPaymentMethodContent();
        }

        #endregion

        //Timer
        private Timer _checkQuantityIsCorrectTimer;

        #region Responsible for change Views accordingly

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

        #endregion

        public InvoiceContent(ApplicationContentView ApplicationContentView)
        {
            this._applicationContentView = ApplicationContentView;

            #region Respective Panel's Data

            //Every single Invoice data is here
            this._invoiceData = new ModelViews.InvoiceContent();

            //Product search panel
            this._productContent = new SearchProductContent(this);
            //Customer search panel
            this._customerContent = new SearchCustomerContent(this);
            //PaymentMethod search panel
            this._paymentMethodContent = new SearchPaymentMethodContent(this);

            #endregion

            InitializeComponent();

            #region Databindings

            //invoice item related data bindings
            InvoiceItemsList.ItemsSource = this._invoiceData.ProductsList;

            InvoiceItemsList.SetBinding(ListBox.SelectedIndexProperty,
                new Binding()
                {
                    Source = this._invoiceData,
                    Path = new PropertyPath("SelectedInvoiceItem"),
                    Mode = BindingMode.OneWayToSource
                });

            RemoveProduct.SetBinding(Button.VisibilityProperty,
                new Binding()
                {
                    Source = this._invoiceData,
                    Path = new PropertyPath("RemoveInvoiceItemButtonVisible"),
                    Mode = BindingMode.OneWay
                });

            //payments related data bindings
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

            ChangeBalanceTextBlock.SetBinding(TextBlock.TextProperty,
                new Binding()
                {
                    Source = this._invoiceData,
                    Path = new PropertyPath("ChangeBalance"),
                    Delay = 500
                });

            //payment method realated data bindings
            InvoicePaymentMethodListView.ItemsSource = this._invoiceData.PaymentMethodsList;

            RemovePaymentMethod.SetBinding(Button.VisibilityProperty,
                new Binding()
                {
                    Source = this._invoiceData,
                    Path = new PropertyPath("RemoveInvoicePaymentMethodButtonVisible"),
                    Mode = BindingMode.OneWay
                });

            InvoicePaymentMethodNotFound.SetBinding(Grid.VisibilityProperty,
                new Binding()
                {
                    Source = this._invoiceData,
                    Path = new PropertyPath("InvoicePaymentMethodNotFound"),
                    Mode = BindingMode.OneWay
                });

            InvoicePaymentMethodListView.SetBinding(ListView.SelectedIndexProperty,
                new Binding()
                {
                    Source = this._invoiceData,
                    Path = new PropertyPath("SelectedInvoicePaymentMethod"),
                    Mode = BindingMode.OneWayToSource
                });

            #endregion

            #region Timer Initializations

            this._checkQuantityIsCorrectTimer = new Timer();
            this._checkQuantityIsCorrectTimer.Elapsed += (s, e) => { try { this.RefreshQuantityInInvoice(); } catch (Exception ez) { Debug.WriteLine("Redda" + ez.ToString()); } };
            this._checkQuantityIsCorrectTimer.Interval = 0.5 * 1000;
            this._checkQuantityIsCorrectTimer.Enabled = true;

            #endregion

            ContentCurrentPage = InvoiceContentCurrentPage.Invoices;
        }

        #region Timer Method

        private bool RefreshQuantityInInvoice()
        {
            if (!(this._invoiceData.ProductsList == null || this._invoiceData.ProductsList.Count == 0))
            {
                bool isAllOk = true;
                float tot = 0F, dis = 0F, payed = 0F;

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
                Debug.WriteLine("P");

                Dispatcher.Invoke(() => 
                {
                    if (isAllOk)
                    {
                        this._invoiceData.NetTotal = string.Format("{0:0.00}", tot - dis);
                        this._invoiceData.GrossTotal = string.Format("{0:0.00}", tot);
                        this._invoiceData.Discount = string.Format("{0:0.00}", dis);

                        bool payedOK = true;
                        payed = 0F;

                        foreach (InvoicePaymentListItemContent Item in this._invoiceData.PaymentMethodsList)
                        {
                            float amountPayed;
                            string amountPayedString = Item.Dispatcher.Invoke(() => { return Item.PaymentAmount; });

                            if (float.TryParse(amountPayedString, out amountPayed))
                            {
                                payed += amountPayed;
                                payedOK = true;
                            }
                            else
                                payedOK = false;

                            if (!payedOK)
                                break;
                        }

                        if (payedOK)
                        {

                            //will change
                            //Dispatcher.Invoke(() => { CompleteInvoice.IsEnabled = true; });
                            this._invoiceData.ChangeBalance = string.Format("{0:0.00}", payed - (tot - dis));
                            return true;
                        }
                        else
                        {

                            //will change
                            //Dispatcher.Invoke(() => { CompleteInvoice.IsEnabled = false; });
                            this._invoiceData.ChangeBalance = "--.--";
                            return false;
                        }
                    }
                    else
                    {
                        this._invoiceData.NetTotal = "--.--";
                        this._invoiceData.GrossTotal = "--.--";
                        this._invoiceData.Discount = "--.--";
                        this._invoiceData.ChangeBalance = "--.--";

                        //Dispatcher.Invoke(() => { CompleteInvoice.IsEnabled = false; });

                        return false;
                    }

                });
                return false;
            }
            else
            {
                Dispatcher.Invoke(() =>
                {
                    this._invoiceData.NetTotal = "--.--";
                    this._invoiceData.GrossTotal = "--.--";
                    this._invoiceData.Discount = "--.--";
                    this._invoiceData.ChangeBalance = "--.--";

                    CompleteInvoice.IsEnabled = false;
                });

                return false;
            }
        }

        #endregion

        #region Invoice Items

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

        private void InvoiceItemsList_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == Key.Delete)
                RemoveProduct_Click(null, null);
        }

        public void AddProductToProductList(Product Product)
        {
            InvoiceItemContent IIC = this._invoiceData.ProductsList.SingleOrDefault(pl => pl.ProductID == Product.ID);

            if (IIC == null)
            {
                this._invoiceData.ProductsList.Add(new InvoiceItemContent()
                {
                    ItemNo = this._invoiceData.ProductsList.Count + 1,
                    ItemPrice = string.Format("{0:0.00}", Math.Round(Product.Price, 2)),
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
                InvoiceItemContent NotifingInvoiceItemContent = InvoiceItemsList.SelectedItem as InvoiceItemContent;
                InvoiceItemsList.ScrollIntoView(NotifingInvoiceItemContent);
                InvoiceItemsList.SelectedIndex = -1;
                NotifingInvoiceItemContent.IsNotify = false;
                NotifingInvoiceItemContent.IsNotify = true;
            }
        }

        #endregion

        #region Choose Customer

        private void SearchCustomer_Click(object sender, RoutedEventArgs e)
        {
            this.ContentCurrentPage = InvoiceContentCurrentPage.Customer;
        }

        #endregion

        #region Payment Method

        private void SearchPaymentMethod_Click(object sender, RoutedEventArgs e)
        {
            this.ContentCurrentPage = InvoiceContentCurrentPage.PaymentMethod;
        }

        public void AddPaymentMethodToList(PaymentMethod PaymentMethod)
        {
            InvoicePaymentListItemContent IPLIC = this._invoiceData.PaymentMethodsList.SingleOrDefault(pm => pm.PaymentMethodName.Equals(PaymentMethod.Name));

            if (IPLIC == null)
            {
                this._invoiceData.AddNewPaymentMethodToInvoice(new InvoicePaymentListItemContent()
                {
                    PaymentMethodName = PaymentMethod.Name,
                    PaymentAmount = "0.00"
                });

                InvoicePaymentMethodListView.SelectedIndex = this._invoiceData.PaymentMethodsList.Count - 1;
                InvoicePaymentMethodListView.ScrollIntoView(InvoicePaymentMethodListView.SelectedItem);
                InvoicePaymentMethodListView.SelectedIndex = -1;
            }
            else
            {

                int itemIndex = this._invoiceData.PaymentMethodsList.IndexOf(IPLIC);
                InvoicePaymentMethodListView.SelectedIndex = itemIndex;
                InvoicePaymentListItemContent NotifingInvoicePaymentMethodContent = InvoicePaymentMethodListView.SelectedItem as InvoicePaymentListItemContent;
                InvoicePaymentMethodListView.ScrollIntoView(NotifingInvoicePaymentMethodContent);
                InvoicePaymentMethodListView.SelectedIndex = -1;
                NotifingInvoicePaymentMethodContent.IsNotify = false;
                NotifingInvoicePaymentMethodContent.IsNotify = true;
            }
        }

        private void InvoicePaymentMethodListView_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Delete)
                RemovePaymentMethod_Click(null, null);
        }

        private void RemovePaymentMethod_Click(object sender, RoutedEventArgs e)
        {
            if (InvoicePaymentMethodListView.SelectedItem != null)
            {
                this._invoiceData.RemovePaymentMethodFromInvoice((InvoicePaymentMethodListView.SelectedIndex));
            }
        }

        #endregion

        #region Universal Invoice inside content hider

        private void ContentPanelBackground_MouseUp(object sender, MouseButtonEventArgs e)
        {
            this.ContentCurrentPage = InvoiceContentCurrentPage.Invoices;
        }


        #endregion

        private void CancelInvoice_Click(object sender, RoutedEventArgs e)
        {
            this._applicationContentView.ResetContentPanel();
        }

        private async void CompleteInvoice_Click(object sender, RoutedEventArgs e)
        {
            CreateInvoiceResource Invoice = new CreateInvoiceResource();
            await new InvoiceAPICall().SendInvoice(Invoice);
            this._applicationContentView.ResetContentPanel();
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
