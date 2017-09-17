//Add MahApps.Metro Namespace
using MahApps.Metro.Controls;

namespace Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            LI1.IsContentWrong = !LI1.IsContentWrong;

            float F1 = float.Parse(LI1.TotalPrice) + 100;

            LI1.TotalPrice = F1.ToString();
        }
    }
}
