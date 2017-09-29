using System.Windows;
using System.Windows.Controls;
using WPF.Views.ApplicationContent;

namespace WPF.Views
{
    /// <summary>
    /// Interaction logic for ApplicationContentView.xaml
    /// </summary>
    public partial class ApplicationContentView : UserControl
    {
        private InvoiceContent _invoiceContent;

        private byte _applicationCurrentContent;

        public ApplicationCurrentView ApplicationCurrentContent
        {
            get
            {
                return (ApplicationCurrentView)this._applicationCurrentContent;
            }
            set
            {
                this._applicationCurrentContent = (byte)value;

                if (value == ApplicationCurrentView.Invoices)
                    this.ApplicationContentCurrentView.Content = this._invoiceContent;
            }
        }



        public ApplicationContentView()
        {
            InitializeComponent();

            this._invoiceContent = new InvoiceContent();

            this.ApplicationCurrentContent = ApplicationCurrentView.Invoices;
        }

        private void UserOptionButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            MainWindow mainWindow = (MainWindow)Window.GetWindow(this);
            mainWindow.ApplicationPage = ApplicationPage.NotLoggedIn;
        }
    }

    public enum ApplicationCurrentView : byte
    {
        Invoices = 0
    }
}
