using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using Models.Persistence;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using WPF.Views;

namespace WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        private bool _isThisFirstTime;
        private byte _applicationPage;

        public ApplicationPage ApplicationPage
        {
            get
            {
                return (ApplicationPage)this._applicationPage;
            }
            set
            {
                this._applicationPage = (byte)ApplicationPage;

                if (value == ApplicationPage.None)
                {
                    this.ChangeApplicationPagesAnimation(TransitionType.Down);
                    this.MainContent.Content = null;
                }
                else if (value == ApplicationPage.NotSetup)
                {
                    this.ChangeApplicationPagesAnimation(TransitionType.Down);
                    this.MainContent.Content = new ApplicationContentView();
                }
                else if (value == ApplicationPage.NotLoggedIn)
                {
                    if (this._isThisFirstTime)
                    {
                        this.ChangeApplicationPagesAnimation(TransitionType.LeftReplace);
                        this._isThisFirstTime = false;
                    }
                    else
                        this.ChangeApplicationPagesAnimation(TransitionType.RightReplace);

                    this.MainContent.Content = new LoginContentView();
                }
                else if (value == ApplicationPage.LoggedIn)
                {
                    this.ChangeApplicationPagesAnimation(TransitionType.LeftReplace);
                    this.MainContent.Content = new ApplicationContentView();
                }
                else if (value == ApplicationPage.NoConnection)
                {
                    this.ChangeApplicationPagesAnimation(TransitionType.Up);
                    this.MainContent.Content = new NoConnectionContentView();
                }
            }
        }

        private bool _isAppLoading;

        public bool IsAppLoading
        {
            get { return this._isAppLoading; }
            set
            {
                this._isAppLoading = value;

                if (value)
                    this.MainWindowLoading.Visibility = System.Windows.Visibility.Visible;
                else
                    this.MainWindowLoading.Visibility = System.Windows.Visibility.Collapsed;
            }
        }

        public MainWindow()
        {
            InitializeComponent();
            this._isThisFirstTime = true;

            ApplicationPage = ApplicationPage.JustLoading;
            IsAppLoading = true;
            LoadDatabaseData();
        }

        public void ChangeApplicationPagesAnimation(TransitionType AnimateTo)
        {
            this.MainContent.Transition = AnimateTo;
        }

        public async void LoadDatabaseData()
        {
            IsAppLoading = true;

            bool check = await Task.Run(
                () =>
                {
                    return InventryMangementSystemDbContext.InitializeData();
                });

            if (check)
            {
                check = await Task.Run(
                    () =>
                    {
                        return InventryMangementSystemDbContext.CheckConnectionToServer();
                    });

                if (check && InventryMangementSystemDbContext.ConnectionCheckFirstTime && InventryMangementSystemDbContext.ConnectionToServer)
                {
                    IsAppLoading = false;
                    ApplicationPage = ApplicationPage.NotLoggedIn;
                }
                else
                {
                    IsAppLoading = false;
                    ApplicationPage = ApplicationPage.NoConnection;
                }
            }
        }
    }

    public enum ApplicationPage : byte
    {
        None,
        NotSetup,
        NotLoggedIn,
        LoggedIn,
        JustLoading,
        NoConnection
    }
}
