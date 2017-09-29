using Styles.Controler;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Controls;

namespace WPF.Views.ApplicationContent
{
    /// <summary>
    /// Interaction logic for InvoiceContent.xaml
    /// </summary>
    public partial class InvoiceContent : UserControl
    {
        ObservableCollection<InvoiceItemContent> InvoiceProducts = new ObservableCollection<InvoiceItemContent>();

        public InvoiceContent()
        {
            InitializeComponent();
        }
    }
}
