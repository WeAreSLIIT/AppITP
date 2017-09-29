using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace InvoiceHandlingApplication.Style.Controler
{
    public class InvoiceItemContent : ContentControl
    {
        public int ItemIndex
        {
            get { return (int)GetValue(ItemIndexProperty); }
            set { SetValue(ItemIndexProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ItemIndex.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ItemIndexProperty =
            DependencyProperty.Register("ItemIndex", typeof(int), typeof(InvoiceItemContent), new PropertyMetadata(0));

        
        public string ProductID
        {
            get { return (string)GetValue(ProductIDProperty); }
            set { SetValue(ProductIDProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ProductID.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ProductIDProperty =
            DependencyProperty.Register("ProductID", typeof(string), typeof(InvoiceItemContent), new PropertyMetadata(null));



        public string ProductDescription
        {
            get { return (string)GetValue(ProductDescriptionProperty); }
            set { SetValue(ProductDescriptionProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ProductDescription.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ProductDescriptionProperty =
            DependencyProperty.Register("ProductDescription", typeof(string), typeof(InvoiceItemContent), new PropertyMetadata(0));



        public float Price
        {
            get { return (float)GetValue(PriceProperty); }
            set { SetValue(PriceProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Price.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty PriceProperty =
            DependencyProperty.Register("Price", typeof(float), typeof(InvoiceItemContent), new PropertyMetadata(0F));



        public float Discount
        {
            get { return (float)GetValue(DiscountProperty); }
            set { SetValue(DiscountProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Discount.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty DiscountProperty =
            DependencyProperty.Register("Discount", typeof(float), typeof(InvoiceItemContent), new PropertyMetadata(0F));



        public float TotalPrice
        {
            get { return (float)GetValue(TotalPriceProperty); }
            set { SetValue(TotalPriceProperty, value); }
        }

        // Using a DependencyProperty as the backing store for TotalPrice.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TotalPriceProperty =
            DependencyProperty.Register("TotalPrice", typeof(float), typeof(InvoiceItemContent), new PropertyMetadata(0));


    }
}
