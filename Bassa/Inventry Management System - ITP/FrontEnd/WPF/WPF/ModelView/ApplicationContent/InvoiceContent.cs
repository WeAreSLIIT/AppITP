using Styles.Controler;
using System.Collections.ObjectModel;
using System.ComponentModel;

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

        private string _grossTotal;

        public string GrossTotal
        {
            get { return this._grossTotal; }
            set
            {
                this._grossTotal = value;
                this.NotifyPropertyChanged("GrossTotal");
            }
        }

        private string _discount;

        public string Discount
        {
            get { return this._discount; }
            set
            {
                this._discount = value;
                this.NotifyPropertyChanged("Discount");
            }
        }

        private string _netTotal;

        public string NetTotal
        {
            get { return this._netTotal; }
            set
            {
                this._netTotal = value;
                this.NotifyPropertyChanged("NetTotal");
            }
        }

        private int _selectedInvoiceItem;

        public int SelectedInvoiceItem
        {
            get { return this._selectedInvoiceItem; }
            set
            {
                this._selectedInvoiceItem = value;
                this.NotifyPropertyChanged("SelectedInvoiceItem");

                this.RemoveInvoiceItemButtonVisible = (value != -1) ? System.Windows.Visibility.Visible : System.Windows.Visibility.Collapsed;
            }
        }

        private string _changeBalance;

        public string ChangeBalance
        {
            get { return this._changeBalance; }
            set
            {
                this._changeBalance = value;
                this.NotifyPropertyChanged("ChangeBalance");
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
                this._selectedInvoicePaymentMethod = value;
                this.NotifyPropertyChanged("SelectedInvoicePaymentMethod");

                this.RemoveInvoicePaymentMethodButtonVisible = (value != -1) ? System.Windows.Visibility.Visible : System.Windows.Visibility.Collapsed;
            }
        }

        private System.Windows.Visibility _removeInvoicePaymentMethodButtonVisible;

        public System.Windows.Visibility RemoveInvoicePaymentMethodButtonVisible
        {
            get { return this._removeInvoicePaymentMethodButtonVisible; }
            private set
            {
                this._removeInvoicePaymentMethodButtonVisible = value;
                this.NotifyPropertyChanged("RemoveInvoicePaymentMethodButtonVisible");
            }
        }

        private System.Windows.Visibility _invoicePaymentMethodNotFound;

        public System.Windows.Visibility InvoicePaymentMethodNotFound
        {
            get { return this._invoicePaymentMethodNotFound; }
            private set
            {
                this._invoicePaymentMethodNotFound = value;
                this.NotifyPropertyChanged("InvoicePaymentMethodNotFound");
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
                this._removeInvoiceItemButtonVisible = value;
                this.NotifyPropertyChanged("RemoveInvoiceItemButtonVisible");
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
            this.ProductsList = new ObservableCollection<InvoiceItemContent>();
            this._grossTotal = "--.--";
            this._discount = "--.--";
            this._netTotal = "--.--";

            this.PaymentMethodsList = new ObservableCollection<InvoicePaymentListItemContent>();
            this._changeBalance = "--.--";

            InvoicePaymentMethodNotFound = System.Windows.Visibility.Visible;
        }

        #endregion
    }
}
