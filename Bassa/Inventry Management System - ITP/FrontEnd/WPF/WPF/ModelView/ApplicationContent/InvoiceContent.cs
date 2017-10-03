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
        
        //products collection

        public ObservableCollection<InvoiceItemContent> ProductsList;

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

        public InvoiceContent()
        {
            ProductsList = new ObservableCollection<InvoiceItemContent>();
            this._grossTotal = "0.00";
            this._discount = "0.00";
            this._netTotal = "0.00";
        }

        public void AddNewProductToInvoice(InvoiceItemContent Product)
        {
            ProductsList.Add(Product);
        }

        public void RemoveProductByIndex(int Index)
        {
            ProductsList.RemoveAt(Index);
        }
    }
}
