//Add MahApps.Metro Namespace
using MahApps.Metro.Controls;
using System.ComponentModel;
using System.Windows.Controls;
using Views.Views.UserControlers;

namespace Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 

    public enum ApplicationPage : byte
    {
        NotSetup = 0,
        NotLoggedIn,
        LoggedIn
    }

    public partial class MainWindow : MetroWindow, INotifyPropertyChanged
    {
        private byte _applicationPage;

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string Property)
        {
            if (this.PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(Property));
        }

        public ApplicationPage ApplicationPage
        {
            get
            {
                return (ApplicationPage)this._applicationPage;
            }
            set
            {
                this._applicationPage = (byte)ApplicationPage;

                if (this._applicationPage == 0)
                    ;
                else if (this._applicationPage == 1)
                    ;
                else if (this._applicationPage == 2)
                    CurrentPage = new MainView();

                OnPropertyChanged("CurrentPage");
            }
        }

        public UserControl CurrentPage { get; private set; }

        public MainWindow()
        {
            InitializeComponent();
        }
    }
}
