using System.Windows;
using System.Windows.Controls;

namespace Styles.Controler
{
    public class InvoiceItemContent : ContentControl
    {
        static InvoiceItemContent() { }

        public int ItemNo
        {
            get { return (int)GetValue(ItemNoProperty); }
            set { SetValue(ItemNoProperty, value); }
        }

        public static readonly DependencyProperty ItemNoProperty =
            DependencyProperty.Register("ItemNo", typeof(int), typeof(InvoiceItemContent), new PropertyMetadata(0));


        public string ProductID
        {
            get { return (string)GetValue(ProductIDProperty); }
            set { SetValue(ProductIDProperty, value); }
        }

        public static readonly DependencyProperty ProductIDProperty =
            DependencyProperty.Register("ProductID", typeof(string), typeof(InvoiceItemContent), new PropertyMetadata("Unknown ###"));


        public string ProductDescription
        {
            get { return (string)GetValue(ProductDescriptionProperty); }
            set { SetValue(ProductDescriptionProperty, value); }
        }

        public static readonly DependencyProperty ProductDescriptionProperty =
            DependencyProperty.Register("ProductDescription", typeof(string), typeof(InvoiceItemContent), new PropertyMetadata("Item ###"));

        public string ItemPrice
        {
            get { return (string)GetValue(ItemPriceProperty); }
            set { SetValue(ItemPriceProperty, value); }
        }

        public static readonly DependencyProperty ItemPriceProperty =
            DependencyProperty.Register("ItemPrice", typeof(string), typeof(InvoiceItemContent), new PropertyMetadata("0.00"));



        public string Discount
        {
            get { return (string)GetValue(DiscountProperty); }
            set { SetValue(DiscountProperty, value); }
        }

        public static readonly DependencyProperty DiscountProperty =
            DependencyProperty.Register("Discount", typeof(string), typeof(InvoiceItemContent), new PropertyMetadata("0.00"));



        public string TotalPrice
        {
            get { return (string)GetValue(TotalPriceProperty); }
            set { SetValue(TotalPriceProperty, value); }
        }

        public static readonly DependencyProperty TotalPriceProperty =
            DependencyProperty.Register("TotalPrice", typeof(string), typeof(InvoiceItemContent), new PropertyMetadata("0.00"));


        public string Quantity
        {
            get { return (string)GetValue(QuantityProperty); }
            set { SetValue(QuantityProperty, value); }
        }

        public static readonly DependencyProperty QuantityProperty =
            DependencyProperty.Register("Quantity", typeof(string), typeof(InvoiceItemContent), new PropertyMetadata("1.000"));
        

        public bool IsContentWrong
        {
            get { return (bool)GetValue(IsContentWrongProperty); }
            set { SetValue(IsContentWrongProperty, value); }
        }
        
        public static readonly DependencyProperty IsContentWrongProperty =
            DependencyProperty.Register("IsContentWrong", typeof(bool), typeof(InvoiceItemContent), new PropertyMetadata(false));


    }
}
