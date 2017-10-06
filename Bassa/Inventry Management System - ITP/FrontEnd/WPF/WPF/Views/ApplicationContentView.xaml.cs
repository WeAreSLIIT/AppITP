using Models.Persistence;
using System;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using WPF.ModelView;
using WPF.Views.ApplicationContent;

namespace WPF.Views
{
    /// <summary>
    /// Interaction logic for ApplicationContentView.xaml
    /// </summary>
    public partial class ApplicationContentView : UserControl
    {
        private Timer RefreshTimer;

        private AppContent _appContent;

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

                if (value == ApplicationCurrentView.None)
                    this.ApplicationContentCurrentView.Content = null;
                else if (value == ApplicationCurrentView.Invoices)
                    this.ApplicationContentCurrentView.Content = this._invoiceContent;
            }
        }

        public ApplicationContentView()
        {
            this._appContent = new AppContent();

            InitializeComponent();
            
            this._invoiceContent = new InvoiceContent(this);

            this.ApplicationCurrentContent = ApplicationCurrentView.Invoices;

            txtCurrentTime.SetBinding(TextBlock.TextProperty,
                new Binding()
                {
                    Source = this._appContent,
                    Path = new PropertyPath("CurrentTime"),
                    Mode = BindingMode.OneWay
                });

            txtCurrentDate.SetBinding(TextBlock.TextProperty,
                new Binding()
                {
                    Source = this._appContent,
                    Path = new PropertyPath("CurrentDate"),
                    Mode = BindingMode.OneWay
                });

            txtSystemStatus.SetBinding(TextBlock.TextProperty,
                new Binding()
                {
                    Source = this._appContent,
                    Path = new PropertyPath("CurrentStatus"),
                    Mode = BindingMode.OneWay
                });

            txtSystemDoingWork.SetBinding(TextBlock.TextProperty,
                new Binding()
                {
                    Source = this._appContent,
                    Path = new PropertyPath("CurrentProgressText"),
                    Mode = BindingMode.OneWay
                });

            progressSystemDoingWork.SetBinding(Grid.VisibilityProperty,
                new Binding()
                {
                    Source = this._appContent,
                    Path = new PropertyPath("CurrentProgressGridVisibility"),
                    Mode = BindingMode.OneWay
                });

            statusBarApplicationStatus.SetBinding(StatusBar.BackgroundProperty,
                new Binding()
                {
                    Source = this._appContent,
                    Path = new PropertyPath("StatusBarBackgroundColor"),
                    Mode = BindingMode.OneWay
                });


            RefreshTimer = new Timer();
            RefreshTimer.Interval = 0.5 * 1000;
            RefreshTimer.Elapsed += RefreshTimer_Elapsed;
            RefreshTimer.Enabled = true;

            RefreshTimer_Elapsed(null, null);


        }

        private void RefreshTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            try
            {
                Dispatcher.Invoke(() =>
                {
                    DateTime CurrentDateTime = TimeConverterMethods.GetCurrentTimeInDateTime();
                    this._appContent.CurrentTime = CurrentDateTime.ToString("hh : mm : ss tt");
                    this._appContent.CurrentDate = CurrentDateTime.ToString("yyyy / MM / dd");

                    this._appContent.ConnectionToServer = InventryMangementSystemDbContext.ConnectionToServer;
                });
            }
            catch { }
        }

        private void UserOptionButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            MainWindow mainWindow = (MainWindow)Window.GetWindow(this);
            mainWindow.ApplicationPage = ApplicationPage.NotLoggedIn;
        }

        public void ResetContentPanel()
        {
            if (ApplicationCurrentContent == ApplicationCurrentView.Invoices)
            {
                ApplicationCurrentContent = ApplicationCurrentView.None;
                this._invoiceContent = new InvoiceContent(this);
                ApplicationCurrentContent = ApplicationCurrentView.Invoices;
            }
        }
    }

    public enum ApplicationCurrentView : byte
    {
        None = 0,
        Invoices
    }
}
