using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using ModelViews = WPF.ModelView.ApplicationContent.InvoiceContents;
using Models.Core;
using WPF.Mappings;
using Styles.Controler;

namespace WPF.Views.ApplicationContent.InvoiceContents
{
    /// <summary>
    /// Interaction logic for SearchProductContent.xaml
    /// </summary>
    public partial class SearchProductContent : UserControl
    {
        private ModelViews.SearchProductContent _searchProductContent;
        private InvoiceContent _invoiceContentUserControl;
        //private Timer _autoSearcher;

        public SearchProductContent(InvoiceContent InvoiceContentUserControl)
        {
            this._invoiceContentUserControl = InvoiceContentUserControl;
            this._searchProductContent = new ModelViews.SearchProductContent();
            InitializeComponent();
            ProductItemsList.ItemsSource = this._searchProductContent.ProductSearchItems;

            SearchProductText.SetBinding(TextBox.TextProperty,
                new Binding()
                {
                    Source = this._searchProductContent,
                    Path = new PropertyPath("SearchKeyWord"),
                    Mode = BindingMode.OneWayToSource,
                    UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged,
                    Delay = 500
                });

            this.ProductItemsList.SetBinding(ListBox.SelectedIndexProperty,
                new Binding()
                {
                    Source = this._searchProductContent,
                    Path = new PropertyPath("CurrentlySelectedItemIndexInResult"),
                    Mode = BindingMode.OneWayToSource
                });

            this.SelectSearchProductContent.SetBinding(Button.IsEnabledProperty,
                new Binding()
                {
                    Source = this._searchProductContent,
                    Path = new PropertyPath("SelectSearchItemButtonEnabled"),
                    Mode = BindingMode.OneWay
                });
        }
        

        private void CloseSearchProductContent_Click(object sender, RoutedEventArgs e)
        {
            SearchProductText.Text = "";
            this._invoiceContentUserControl.ContentCurrentPage = InvoiceContentCurrentPage.Invoices;
        }

        private void SelectSearchProductContent_Click(object sender, RoutedEventArgs e)
        {
            SelectItemFromList();
        }

        private void ProductItemsList_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                SelectItemFromList();
            }
        }

        private void SelectItemFromList()
        {
            if (this._searchProductContent.CurrentlySelectedItemIndexInResult != -1)
            {
                this._invoiceContentUserControl.AddProductToProductList(new ProductMapping().ProductToProductSearchItem(ProductItemsList.SelectedItem as ProductSearchItem));
                this.CloseSearchProductContent_Click(null, null);
            }
        }
    }
}
