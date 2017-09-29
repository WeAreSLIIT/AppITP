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

        ObservableCollection<InvoiceItemContent> Products = new ObservableCollection<InvoiceItemContent>();

        public void AddNewProductToInvoice(InvoiceItemContent Product)
        {
            Products.Add(Product);
        }

        public void RemoveProductByIndex(int Index)
        {
            Products.RemoveAt(Index);
        }

        //
    }
}
