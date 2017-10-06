using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Styles.Controler
{
    public class PaymentSearchItem : ContentControl
    {
        public int ItemNo
        {
            get { return (int)GetValue(ItemNoProperty); }
            set { SetValue(ItemNoProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ItemNo.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ItemNoProperty =
            DependencyProperty.Register("ItemNo", typeof(int), typeof(PaymentSearchItem), new PropertyMetadata(0));



        public SolidColorBrush ListBackgroundColor
        {
            get { return (SolidColorBrush)GetValue(ListBackgroundColorProperty); }
            private set { SetValue(ListBackgroundColorProperty, value); }
        }

        public static readonly DependencyProperty ListBackgroundColorProperty =
            DependencyProperty.Register("ListBackgroundColor", typeof(SolidColorBrush), typeof(PaymentSearchItem), new PropertyMetadata((SolidColorBrush)(new BrushConverter().ConvertFrom("#f9f9f9"))));
        
        public string PaymentName
        {
            get { return (string)GetValue(PaymentNameProperty); }
            set { SetValue(PaymentNameProperty, value); }
        }

        public static readonly DependencyProperty PaymentNameProperty =
            DependencyProperty.Register("PaymentName", typeof(string), typeof(PaymentSearchItem), new PropertyMetadata("###"));


        public string PaymentDescription
        {
            get { return (string)GetValue(PaymentDescriptionProperty); }
            set { SetValue(PaymentDescriptionProperty, value); }
        }

        public static readonly DependencyProperty PaymentDescriptionProperty =
            DependencyProperty.Register("PaymentDescription", typeof(string), typeof(PaymentSearchItem), new PropertyMetadata("Payment ###"));

        
        static PaymentSearchItem() { }
    }
}
