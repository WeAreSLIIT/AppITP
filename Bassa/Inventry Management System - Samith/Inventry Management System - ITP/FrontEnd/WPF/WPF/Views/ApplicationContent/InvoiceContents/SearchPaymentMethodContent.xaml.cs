using Styles.Controler;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using WPF.Mappings;
using WPFs = WPF.ModelView.ApplicationContent.InvoiceContents;

namespace WPF.Views.ApplicationContent.InvoiceContents
{
    /// <summary>
    /// Interaction logic for SearchPaymentMethodContent.xaml
    /// </summary>
    public partial class SearchPaymentMethodContent : UserControl
    {
        private InvoiceContent _invoiceContentUserControl;
        private WPFs.SearchPaymentMethodContent _searchPaymentMethodContent;

        public SearchPaymentMethodContent(InvoiceContent InvoiceContentUserControl)
        {
            this._invoiceContentUserControl = InvoiceContentUserControl;
            this._searchPaymentMethodContent = new WPFs.SearchPaymentMethodContent();

            InitializeComponent();

            this.PayementMethodsList.ItemsSource = this._searchPaymentMethodContent.PaymentSearchList;

            SearchPaymentText.SetBinding(TextBox.TextProperty,
                new Binding()
                {
                    Source = this._searchPaymentMethodContent,
                    Path = new PropertyPath("SearchKeyWord"),
                    Mode = BindingMode.OneWayToSource,
                    UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged,
                    Delay = 500
                });

            this.PayementMethodsList.SetBinding(ListBox.SelectedIndexProperty,
                new Binding()
                {
                    Source = this._searchPaymentMethodContent,
                    Path = new PropertyPath("CurrentlySelectedItemIndexInResult"),
                    Mode = BindingMode.OneWayToSource
                });

            this.SelectSearchPaymentMethodContent.SetBinding(Button.IsEnabledProperty,
                new Binding()
                {
                    Source = this._searchPaymentMethodContent,
                    Path = new PropertyPath("SelectSearchItemButtonEnabled"),
                    Mode = BindingMode.OneWay
                });

            this.PaymentMethodsFound.SetBinding(StackPanel.VisibilityProperty,
                new Binding()
                {
                    Source = this._searchPaymentMethodContent,
                    Path = new PropertyPath("IsItemsFoundVisibility"),
                    Mode = BindingMode.OneWay
                });

            this.PaymentMethodsNotFound.SetBinding(StackPanel.VisibilityProperty,
                new Binding()
                {
                    Source = this._searchPaymentMethodContent,
                    Path = new PropertyPath("IsItemsNotFoundVisibility"),
                    Mode = BindingMode.OneWay
                });

        }

        private void CloseSearchPaymentMethodContent_Click(object sender, RoutedEventArgs e)
        {
            this._invoiceContentUserControl.ContentCurrentPage = InvoiceContentCurrentPage.Invoices;
            this._invoiceContentUserControl.ResetSearchPaymentMethodContent();
        }

        private void SelectSearchPaymentMethodContent_Click(object sender, RoutedEventArgs e)
        {
            SelectItemFromList();
        }

        private void PayementMethodsList_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                SelectItemFromList();
            }
        }

        private void SelectItemFromList()
        {
            if (this._searchPaymentMethodContent.CurrentlySelectedItemIndexInResult != -1)
            {
                this._invoiceContentUserControl.AddPaymentMethodToList(new PaymentMethodMapping().PaymentMethodToPaymentSearchItem(PayementMethodsList.SelectedItem as PaymentSearchItem));
                this.CloseSearchPaymentMethodContent_Click(null, null);
            }
        }
    }
}
