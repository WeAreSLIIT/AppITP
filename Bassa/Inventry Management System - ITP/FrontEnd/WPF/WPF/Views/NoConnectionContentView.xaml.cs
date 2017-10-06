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

namespace WPF.Views
{
    /// <summary>
    /// Interaction logic for NoConnectionContentView.xaml
    /// </summary>
    public partial class NoConnectionContentView : UserControl
    {
        public NoConnectionContentView()
        {
            InitializeComponent();
        }

        private void ConnectionTrayAgain_Click(object sender, RoutedEventArgs e)
        {
            MainWindow CurrentWindow = (MainWindow)Window.GetWindow(this);
            CurrentWindow.LoadDatabaseData();
            CurrentWindow.ApplicationPage = ApplicationPage.None;
        }
    }
}
