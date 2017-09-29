using MahApps.Metro.Controls;
using System.ComponentModel;
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

                if (value == ApplicationPage.NotSetup)
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

            ApplicationPage = ApplicationPage.NotLoggedIn;
            IsAppLoading = false;
        }

        public void ChangeApplicationPagesAnimation(TransitionType AnimateTo)
        {
            this.MainContent.Transition = AnimateTo;
        }
    }

    public enum ApplicationPage : byte
    {
        NotSetup = 0,
        NotLoggedIn,
        LoggedIn
    }
}
