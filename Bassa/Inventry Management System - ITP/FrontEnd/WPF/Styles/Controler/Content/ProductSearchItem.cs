using System.Windows;
using System.Windows.Controls;

namespace Styles.Controler
{
    public class ProductSearchItem : ContentControl
    {
        public int ItemNo
        {
            get { return (int)GetValue(ItemNoProperty); }
            set { SetValue(ItemNoProperty, value); }
        }

        public static readonly DependencyProperty ItemNoProperty =
            DependencyProperty.Register("ItemNo", typeof(int), typeof(ProductSearchItem), new PropertyMetadata(0));


        public string ProductID
        {
            get { return (string)GetValue(ProductIDProperty); }
            set { SetValue(ProductIDProperty, value); }
        }

        public static readonly DependencyProperty ProductIDProperty =
            DependencyProperty.Register("ProductID", typeof(string), typeof(ProductSearchItem), new PropertyMetadata("Unknown ###"));


        public string ProductDescription
        {
            get { return (string)GetValue(ProductDescriptionProperty); }
            set { SetValue(ProductDescriptionProperty, value); }
        }

        public static readonly DependencyProperty ProductDescriptionProperty =
            DependencyProperty.Register("ProductDescription", typeof(string), typeof(ProductSearchItem), new PropertyMetadata("Item ###"));

        public string ItemPrice
        {
            get { return (string)GetValue(ItemPriceProperty); }
            set { SetValue(ItemPriceProperty, value); }
        }

        public static readonly DependencyProperty ItemPriceProperty =
            DependencyProperty.Register("ItemPrice", typeof(string), typeof(ProductSearchItem), new PropertyMetadata("0.00"));


        public string Discount
        {
            get { return (string)GetValue(DiscountProperty); }
            set { SetValue(DiscountProperty, value); }
        }

        public static readonly DependencyProperty DiscountProperty =
            DependencyProperty.Register("Discount", typeof(string), typeof(ProductSearchItem), new PropertyMetadata("0.00"));
        
        public ProductType ItemType
        {
            get { return (ProductType)GetValue(ItemTypeProperty); }
            set { SetValue(ItemTypeProperty, value); }
        }

        public static readonly DependencyProperty ItemTypeProperty =
            DependencyProperty.Register("ItemType", typeof(ProductType), typeof(ProductSearchItem), new PropertyMetadata(ProductType.Measurable));
        
        static ProductSearchItem() { }
    }
}
