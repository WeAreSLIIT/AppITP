using System.ComponentModel;
using System.Windows.Media;

namespace WPF.ModelView
{
    public class AppContent : INotifyPropertyChanged
    {
        #region Notify Property Changed

        public event PropertyChangedEventHandler PropertyChanged;

        public void NotifyPropertyChanged(string propName)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }

        #endregion

        private bool _connectionToServer;

        public bool ConnectionToServer
        {
            get { return this._connectionToServer; }
            set
            {
                if (this.ConnectionToServer != value)
                {
                    this._connectionToServer = value;

                    if (value)
                    {
                        this.StatusBarBackgroundColor = (SolidColorBrush)(new BrushConverter().ConvertFrom("#2a3f54"));
                        this.CurrentStatus = "Connected";
                    }
                    else
                    {
                        this.StatusBarBackgroundColor = (SolidColorBrush)(new BrushConverter().ConvertFrom("#78140a"));
                        this.CurrentStatus = "Not-Connected";
                    }
                }
            }
        }


        private string _currentTime;

        public string CurrentTime
        {
            get { return this._currentTime; }
            set
            {
                if (this._currentTime == null || !this._currentTime.Equals(value))
                {
                    this._currentTime = value;
                    this.NotifyPropertyChanged("CurrentTime");
                }
            }
        }

        private string _currentDate;

        public string CurrentDate
        {
            get { return this._currentDate; }
            set
            {
                if (this._currentDate == null || !this._currentDate.Equals(value))
                {
                    this._currentDate = value;
                    this.NotifyPropertyChanged("CurrentDate");
                }
            }
        }

        private string _currentStatus;

        public string CurrentStatus
        {
            get { return this._currentStatus; }
            private set
            {
                if (this._currentStatus == null || !this._currentStatus.Equals(value))
                {
                    this._currentStatus = value;
                    this.NotifyPropertyChanged("CurrentStatus");
                }
            }
        }

        private string _currentProgressText;

        public string CurrentProgressText
        {
            get { return this._currentProgressText; }
            private set
            {
                if (this._currentProgressText == null || !this._currentProgressText.Equals(value))
                {
                    this._currentProgressText = value;
                    this.NotifyPropertyChanged("CurrentProgressText");
                }
            }
        }

        private System.Windows.Visibility _currentProgressGrid;

        public System.Windows.Visibility CurrentProgressGridVisibility
        {
            get { return this._currentProgressGrid; }
            private set
            {
                if (this._currentProgressGrid != value)
                {
                    this._currentProgressGrid = value;
                    this.NotifyPropertyChanged("CurrentProgressGridVisibility");
                }
            }
        }

        private SolidColorBrush _statusBarBackgroundColor;

        public SolidColorBrush StatusBarBackgroundColor
        {
            get { return this._statusBarBackgroundColor; }
            private set
            {
                if (this._statusBarBackgroundColor == null || this._statusBarBackgroundColor != value)
                {
                    this._statusBarBackgroundColor = value;
                    this.NotifyPropertyChanged("StatusBarBackgroundColor");
                }
            }
        }


        public void SetCurrentProgress(bool Active)
        {
            SetCurrentProgress(Active, "");
        }

        public void SetCurrentProgress(bool Active, string Message = "")
        {
            if (!(Active && CheckIsInProgress()))
            {
                this.CurrentProgressText = Message;

                if (Active)
                    CurrentProgressGridVisibility = System.Windows.Visibility.Visible;
                else
                    CurrentProgressGridVisibility = System.Windows.Visibility.Collapsed;
            }
        }

        public bool CheckIsInProgress()
        {
            return (CurrentProgressGridVisibility == System.Windows.Visibility.Visible);
        }

        public AppContent()
        {
            this.ConnectionToServer = false;
            this._currentProgressGrid = System.Windows.Visibility.Visible;
            this.SetCurrentProgress(false);
            this.CurrentDate = "---- / -- / --";
            this.CurrentTime = "-- : -- : -- --";
            this.CurrentStatus = "Checking...";
        }
    }
}
