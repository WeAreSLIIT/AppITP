using Models.Core;
using Models.Persistence;
using Styles.Controler;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using WPF.Mappings;

namespace WPF.ModelView.ApplicationContent.InvoiceContents
{
    public class SearchPaymentMethodContent : INotifyPropertyChanged
    {
        #region Notify Property Changed

        public event PropertyChangedEventHandler PropertyChanged;

        public void NotifyPropertyChanged(string propName)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }

        #endregion


        private PaymentMethodMapping _paymentMethodMapping;

        public ObservableCollection<PaymentSearchItem> PaymentSearchList;

        private string _oldSearchKeyWord;
        private string _searchKeyWord;

        public string SearchKeyWord
        {
            get { return this._searchKeyWord; }
            set
            {
                this._searchKeyWord = value;
                this.NotifyPropertyChanged("SearchKeyWord");
                this.RefreshPaymentMethodSearchItems();
            }
        }

        private int _currentlySelectedItemIndexInResult;

        public int CurrentlySelectedItemIndexInResult
        {
            get { return this._currentlySelectedItemIndexInResult; }
            set
            {
                this._currentlySelectedItemIndexInResult = value;
                this.NotifyPropertyChanged("CurrentlySelectedItemIndexInResult");

                this.SelectSearchItemButtonEnabled = (value != -1);
            }
        }

        private bool _selectSearchItemButtonEnabled;

        public bool SelectSearchItemButtonEnabled
        {
            get { return this._selectSearchItemButtonEnabled; }
            set
            {
                this._selectSearchItemButtonEnabled = value;
                this.NotifyPropertyChanged("SelectSearchItemButtonEnabled");
            }
        }

        private System.Windows.Visibility _isItemsFoundVisibility;

        public System.Windows.Visibility IsItemsFoundVisibility
        {
            get { return this._isItemsFoundVisibility; }
            private set
            {
                if (this._isItemsFoundVisibility != value)
                {
                    this._isItemsFoundVisibility = value;
                    this.NotifyPropertyChanged("IsItemsFoundVisibility");

                    if (value == System.Windows.Visibility.Visible)
                        this.IsItemsNotFoundVisibility = System.Windows.Visibility.Collapsed;
                    else
                        this.IsItemsNotFoundVisibility = System.Windows.Visibility.Visible;
                }
            }
        }

        private System.Windows.Visibility _isItemsNotFoundVisibility;

        public System.Windows.Visibility IsItemsNotFoundVisibility
        {
            get { return this._isItemsNotFoundVisibility; }
            private set
            {
                if (this._isItemsNotFoundVisibility != value)
                {
                    this._isItemsNotFoundVisibility = value;
                    this.NotifyPropertyChanged("IsItemsNotFoundVisibility");

                    if (value == System.Windows.Visibility.Visible)
                        this.IsItemsFoundVisibility = System.Windows.Visibility.Collapsed;
                    else
                        this.IsItemsFoundVisibility = System.Windows.Visibility.Visible;
                }
            }
        }

        private void RefreshPaymentMethodSearchItems()
        {
            int index = 0;

            if (this._oldSearchKeyWord == null || this.SearchKeyWord == null)
            {
                if (this._oldSearchKeyWord == null)
                    this._oldSearchKeyWord = "";

                if (this.SearchKeyWord == null)
                    this.SearchKeyWord = "";
            }

            bool PaymentMethodSearchItemsIsChanged = false;

            ICollection<PaymentMethod> PaymentMethods = new List<PaymentMethod>();
            PaymentMethods = InventryMangementSystemDbContext.PaymentMethods;

            ICollection<PaymentMethod> FilteredPaymentMethods = new List<PaymentMethod>();

            if (this._oldSearchKeyWord.Equals("") && this.SearchKeyWord.Equals(""))
            {
                FilteredPaymentMethods = PaymentMethods.Take(20).ToList();
                PaymentMethodSearchItemsIsChanged = true;
            }

            if (!this._oldSearchKeyWord.Equals(this.SearchKeyWord))
            {
                FilteredPaymentMethods = PaymentMethods.Where(pm => pm.Name.ToLower().Contains(this.SearchKeyWord.ToLower()) ||
                pm.Note.ToLower().Contains(this.SearchKeyWord.ToLower())).Take(20).ToList();

                PaymentMethodSearchItemsIsChanged = true;
            }

            if (PaymentMethodSearchItemsIsChanged)
            {
                this.PaymentSearchList.Clear();

                if (!(FilteredPaymentMethods == null || FilteredPaymentMethods.Count == 0))
                {
                    this.IsItemsFoundVisibility = System.Windows.Visibility.Visible;

                    foreach (PaymentMethod PaymentMethod in FilteredPaymentMethods)
                    {
                        PaymentSearchItem Temp = this._paymentMethodMapping.PaymentMethodToPaymentSearchItem(PaymentMethod);
                        Temp.ItemNo = ++index;
                        this.PaymentSearchList.Add(Temp);
                    }
                }
                else
                    this.IsItemsFoundVisibility = System.Windows.Visibility.Collapsed;
            }

            this._oldSearchKeyWord = this.SearchKeyWord;
        }

        public SearchPaymentMethodContent()
        {
            this.PaymentSearchList = new ObservableCollection<PaymentSearchItem>();
            this._paymentMethodMapping = new PaymentMethodMapping();

            this._oldSearchKeyWord = "";
            this.SearchKeyWord = "";

            this.CurrentlySelectedItemIndexInResult = -1;
            this.IsItemsFoundVisibility = System.Windows.Visibility.Collapsed;
        }
    }
}
