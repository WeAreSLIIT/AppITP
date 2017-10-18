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
    public class SearchProductContent : INotifyPropertyChanged
    {
        #region Notify Property Changed

        public event PropertyChangedEventHandler PropertyChanged;

        public void NotifyPropertyChanged(string propName)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }

        #endregion

        private ProductMapping _productMapping;

        public ObservableCollection<ProductSearchItem> ProductSearchItems;

        private string _oldSearchKeyWord;
        private string _searchKeyWord;

        public string SearchKeyWord
        {
            get { return this._searchKeyWord; }
            set
            {
                this._searchKeyWord = value;
                this.NotifyPropertyChanged("SearchKeyWord");
                this.RefreshProductSearchItems();
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

        private void RefreshProductSearchItems()
        {
            int index = 0;

            if (this._oldSearchKeyWord == null || this.SearchKeyWord == null)
            {
                if (this._oldSearchKeyWord == null)
                    this._oldSearchKeyWord = "";

                if (this.SearchKeyWord == null)
                    this.SearchKeyWord = "";
            }

            bool ProductSearchItemsIsChanged = false;

            ICollection<Product> Products = new List<Product>();
            Products = InventryMangementSystemDbContext.Products;

            ICollection<Product> FilteredProducts = new List<Product>();

            if (this._oldSearchKeyWord.Equals("") && this.SearchKeyWord.Equals(""))
            {
                FilteredProducts = Products.Take(20).ToList();
                ProductSearchItemsIsChanged = true;
            }

            if (!this._oldSearchKeyWord.Equals(this.SearchKeyWord))
            {
                FilteredProducts = Products.Where(p => p.ID.ToLower().Contains(
                    this.SearchKeyWord.ToLower()) ||
                    p.Bracode.ToLower().Contains(this.SearchKeyWord.ToLower()) ||
                    p.Name.ToLower().Contains(this.SearchKeyWord.ToLower())).Take(20).ToList();

                ProductSearchItemsIsChanged = true;
            }

            if (ProductSearchItemsIsChanged)
            {
                this.ProductSearchItems.Clear();

                if (!(FilteredProducts == null || FilteredProducts.Count == 0))
                {
                    this.IsItemsFoundVisibility = System.Windows.Visibility.Visible;

                    foreach (Product Product in FilteredProducts)
                    {
                        ProductSearchItem Temp = this._productMapping.ProductToProductSearchItem(Product);
                        Temp.ItemNo = ++index;
                        this.ProductSearchItems.Add(Temp);
                    }
                }
                else
                    this.IsItemsFoundVisibility = System.Windows.Visibility.Collapsed;
            }

            this._oldSearchKeyWord = this.SearchKeyWord;
        }

        public SearchProductContent()
        {
            this.ProductSearchItems = new ObservableCollection<ProductSearchItem>();
            this._productMapping = new ProductMapping();

            this._oldSearchKeyWord = "";
            this.SearchKeyWord = "";

            CurrentlySelectedItemIndexInResult = -1;
            this.IsItemsFoundVisibility = System.Windows.Visibility.Collapsed;
        }
    }
}
