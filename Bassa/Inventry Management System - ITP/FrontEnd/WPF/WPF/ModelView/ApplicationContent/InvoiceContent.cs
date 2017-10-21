using Models.ADO;
using Models.APICall.Resources;
using Models.Core;
using Models.Persistence;
using Styles.Controler;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace WPF.ModelView.ApplicationContent
{
    public class InvoiceContent : INotifyPropertyChanged
    {
        #region Notify Property Changed

        public event PropertyChangedEventHandler PropertyChanged;

        public void NotifyPropertyChanged(string propName)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }

        #endregion

        #region Properties of Invoice

        private bool IsInvoiceProcessing;

        private bool _isInvoiceValid;

        public bool IsInvoiceValid
        {
            get { return this._isInvoiceValid; }
            set
            {
                if (IsInvoiceValid != value && IsInvoiceProcessing == false)
                {
                    this._isInvoiceValid = value;
                    this.NotifyPropertyChanged("IsInvoiceValid");
                }
            }
        }

        private string _grossTotal;

        public string GrossTotal
        {
            get { return this._grossTotal; }
            set
            {
                if (GrossTotal == null || !GrossTotal.Equals(value))
                {
                    this._grossTotal = value;
                    this.NotifyPropertyChanged("GrossTotal");
                }
            }
        }

        private string _discount;

        public string Discount
        {
            get { return this._discount; }
            set
            {
                if (Discount == null || !Discount.Equals(value))
                {
                    this._discount = value;
                    this.NotifyPropertyChanged("Discount");
                }
            }
        }

        private string _netTotal;

        public string NetTotal
        {
            get { return this._netTotal; }
            set
            {
                if (NetTotal == null || !NetTotal.Equals(value))
                {
                    this._netTotal = value;
                    this.NotifyPropertyChanged("NetTotal");
                }
            }
        }

        private int _selectedInvoiceItem;

        public int SelectedInvoiceItem
        {
            get { return this._selectedInvoiceItem; }
            set
            {
                if (SelectedInvoiceItem != value)
                {
                    this._selectedInvoiceItem = value;
                    this.NotifyPropertyChanged("SelectedInvoiceItem");

                    this.RemoveInvoiceItemButtonVisible = (value != -1) ? System.Windows.Visibility.Visible : System.Windows.Visibility.Collapsed;
                }
            }
        }

        private string _changeBalance;

        public string ChangeBalance
        {
            get { return this._changeBalance; }
            set
            {
                if (ChangeBalance == null || !ChangeBalance.Equals(value))
                {
                    this._changeBalance = value;
                    this.NotifyPropertyChanged("ChangeBalance");
                }
            }
        }

        #endregion

        #region Invoice Payment Method

        public ObservableCollection<InvoicePaymentListItemContent> PaymentMethodsList;

        private int _selectedInvoicePaymentMethod;

        public int SelectedInvoicePaymentMethod
        {
            get { return this._selectedInvoicePaymentMethod; }
            set
            {
                if (SelectedInvoicePaymentMethod != value)
                {
                    this._selectedInvoicePaymentMethod = value;
                    this.NotifyPropertyChanged("SelectedInvoicePaymentMethod");

                    this.RemoveInvoicePaymentMethodButtonVisible = (value != -1) ? System.Windows.Visibility.Visible : System.Windows.Visibility.Collapsed;
                }
            }
        }

        private System.Windows.Visibility _removeInvoicePaymentMethodButtonVisible;

        public System.Windows.Visibility RemoveInvoicePaymentMethodButtonVisible
        {
            get { return this._removeInvoicePaymentMethodButtonVisible; }
            private set
            {
                if (RemoveInvoicePaymentMethodButtonVisible != value)
                {
                    this._removeInvoicePaymentMethodButtonVisible = value;
                    this.NotifyPropertyChanged("RemoveInvoicePaymentMethodButtonVisible");
                }
            }
        }

        private System.Windows.Visibility _invoicePaymentMethodNotFound;

        public System.Windows.Visibility InvoicePaymentMethodNotFound
        {
            get { return this._invoicePaymentMethodNotFound; }
            private set
            {
                if (InvoicePaymentMethodNotFound != value)
                {
                    this._invoicePaymentMethodNotFound = value;
                    this.NotifyPropertyChanged("InvoicePaymentMethodNotFound");
                }
            }
        }

        public void AddNewPaymentMethodToInvoice(InvoicePaymentListItemContent PaymentMethod)
        {
            this.PaymentMethodsList.Add(PaymentMethod);

            if (InvoicePaymentMethodNotFound != System.Windows.Visibility.Collapsed)
                InvoicePaymentMethodNotFound = System.Windows.Visibility.Collapsed;
        }

        public void RemovePaymentMethodFromInvoice(int Index)
        {
            this.PaymentMethodsList.RemoveAt(Index);

            if (PaymentMethodsList.Count == 0)
                InvoicePaymentMethodNotFound = System.Windows.Visibility.Visible;

        }

        #endregion

        #region Invoice Items List

        public ObservableCollection<InvoiceItemContent> ProductsList;

        private System.Windows.Visibility _removeInvoiceItemButtonVisible;

        public System.Windows.Visibility RemoveInvoiceItemButtonVisible
        {
            get { return this._removeInvoiceItemButtonVisible; }
            private set
            {
                if (RemoveInvoiceItemButtonVisible != value)
                {
                    this._removeInvoiceItemButtonVisible = value;
                    this.NotifyPropertyChanged("RemoveInvoiceItemButtonVisible");
                }
            }
        }

        public void AddNewProductToInvoice(InvoiceItemContent Product)
        {
            this.ProductsList.Add(Product);
        }

        public void RemoveProductByIndex(int Index)
        {
            this.ProductsList.RemoveAt(Index);
        }

        #endregion

        #region Constructor

        public InvoiceContent()
        {
            this.IsInvoiceProcessing = false;

            this.ProductsList = new ObservableCollection<InvoiceItemContent>();
            this._grossTotal = "--.--";
            this._discount = "--.--";
            this._netTotal = "--.--";

            this.PaymentMethodsList = new ObservableCollection<InvoicePaymentListItemContent>();
            this._changeBalance = "--.--";

            InvoicePaymentMethodNotFound = System.Windows.Visibility.Visible;
        }

        #endregion

        #region Submit Invoice

        public async Task<bool> SubmitInvoice()
        {
            try
            {
                if (this.IsInvoiceValid)
                {
                    this.IsInvoiceValid = false;
                    this.IsInvoiceProcessing = true;

                    await Task.Run(() => Thread.Sleep(200));

                    return await Task.Run(
                        () =>
                        {

                            string newInvoiceID = TimeConverterMethods.GetCurrentTimeInDateTime().ToString("yyMMdd") + "-" +
                                        InventryMangementSystemDbContext.CounterWorking.BranchID.ToString("00") + "-" +
                                        InventryMangementSystemDbContext.CounterWorking.CouterNo.ToString("00") + "-" +
                                        //InventryMangementSystemDbContext.EmployeeWorking.ID.ToString("0000") + "-" +
                                        (DBConnection.GetRowCount(DatabaseTable.Invoice) + 1).ToString("00");
                            
                            Invoice NewInvoice = new Invoice()
                            {
                                InvoiceId = newInvoiceID,
                                Time = TimeConverterMethods.GetCurrentTimeInLong(),
                                Balance = float.Parse(this.ChangeBalance),
                                Counter = InventryMangementSystemDbContext.CounterWorking,
                                Discount = float.Parse(this.Discount),
                                FullPayment = float.Parse(this.GrossTotal),
                                Payed = float.Parse(this.NetTotal),
                                IssuedBy = InventryMangementSystemDbContext.EmployeeWorking.ID
                            };

                            NewInvoice.InvoiceDeal = null;
                            NewInvoice.PurchasedBy = null;

                            foreach (InvoiceItemContent Product in this.ProductsList)
                            {
                                Product.Dispatcher.Invoke(
                                    () =>
                                    {
                                        NewInvoice.Products.Add(new InvoiceProduct()
                                        {
                                            ID = Product.ProductID,
                                            Quantity = float.Parse(Product.Quantity)
                                        });
                                    });
                            }

                            foreach (InvoicePaymentListItemContent Payment in this.PaymentMethodsList)
                            {
                                Payment.Dispatcher.Invoke(
                                    () =>
                                    {
                                        NewInvoice.Payments.Add(new InvoicePaymentMethod()
                                        {
                                            Method = Payment.PaymentMethodName,
                                            Amount = float.Parse(Payment.PaymentAmount)
                                        });
                                    });
                            }
                            
                            return InventryMangementSystemDbContext.AddNewInvoice(NewInvoice);
                        });
                }
                else
                    return false;
            }
            finally
            {
                this.IsInvoiceProcessing = false;
            }


        }

        #endregion

    }

    public enum InvoiceSubmitError : byte
    {
        None = 0,
        NoProduct,
        NoPaymentMethod
    }
}
