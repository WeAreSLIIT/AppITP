using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WPF.Views.ApplicationContent.InvoiceContents
{
    /// <summary>
    /// Interaction logic for SearchCustomerContent.xaml
    /// </summary>
    public partial class SearchCustomerContent : UserControl
    {
        private InvoiceContent _invoiceContentUserControl;

        public SearchCustomerContent(InvoiceContent InvoiceContentUserControl)
        {
            this._invoiceContentUserControl = InvoiceContentUserControl;
            InitializeComponent();
        }

        private void CloseSearchCustomerContent_Click(object sender, RoutedEventArgs e)
        {
            this._invoiceContentUserControl.ContentCurrentPage = InvoiceContentCurrentPage.Invoices;
            this._invoiceContentUserControl.ResetSearchCustomerContent();
        }
    }
}
