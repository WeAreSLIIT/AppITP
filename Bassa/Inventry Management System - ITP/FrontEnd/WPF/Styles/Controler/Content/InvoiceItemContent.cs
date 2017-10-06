using System;
using System.Windows;
using System.Windows.Controls;

namespace Styles.Controler
{
    public enum ProductType
    {
        Unit,
        Measurable
    }

    public class InvoiceItemContent : ContentControl
    {
        static InvoiceItemContent() { }
        
        public bool AllSettedUp
        {
            get { return (bool)GetValue(AllSettedUpProperty); }
            set
            {
                SetValue(AllSettedUpProperty, value);
                this.CalculateTotalPrice();
            }
        }
        
        public static readonly DependencyProperty AllSettedUpProperty =
            DependencyProperty.Register("AllSettedUp", typeof(bool), typeof(InvoiceItemContent), new PropertyMetadata(false));
        
        public ProductType ItemType
        {
            get { return (ProductType)GetValue(ItemTypeProperty); }
            set { SetValue(ItemTypeProperty, value); }
        }
        
        public static readonly DependencyProperty ItemTypeProperty =
            DependencyProperty.Register("ItemType", typeof(ProductType), typeof(InvoiceItemContent), new PropertyMetadata(ProductType.Measurable));

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
            private set { SetValue(TotalPriceProperty, value); }
        }

        public static readonly DependencyProperty TotalPriceProperty =
            DependencyProperty.Register("TotalPrice", typeof(string), typeof(InvoiceItemContent), new PropertyMetadata("0.00"));


        public string Quantity
        {
            get { return (string)GetValue(QuantityProperty); }
            set { SetValue(QuantityProperty, value); }
        }

        public static readonly DependencyProperty QuantityProperty =
            DependencyProperty.Register("Quantity", typeof(string), typeof(InvoiceItemContent),
                new PropertyMetadata("1",
                    (sender, e) =>
                    {
                        InvoiceItemContent Sender = sender as InvoiceItemContent;
                        if (Sender != null)
                        {
                            if (Sender.ItemType == ProductType.Unit)
                            {
                                int i = 0;
                                Sender.IsContentWrong = !int.TryParse(Sender.Quantity, out i) || (i == 0);
                            }
                            else if (Sender.ItemType == ProductType.Measurable)
                            {
                                float f = 0F;
                                Sender.IsContentWrong = !float.TryParse(Sender.Quantity, out f) || (f == 0F);
                            }

                            Sender.CalculateTotalPrice();
                        }
                    }));



        public bool IsNotify
        {
            get { return (bool)GetValue(IsNotifyProperty); }
            set { SetValue(IsNotifyProperty, value); }
        }
        
        public static readonly DependencyProperty IsNotifyProperty =
            DependencyProperty.Register("IsNotify", typeof(bool), typeof(InvoiceItemContent), new PropertyMetadata(false));

        public bool IsContentWrong
        {
            get { return (bool)GetValue(IsContentWrongProperty); }
            private set { SetValue(IsContentWrongProperty, value); }
        }

        public static readonly DependencyProperty IsContentWrongProperty =
            DependencyProperty.Register("IsContentWrong", typeof(bool), typeof(InvoiceItemContent), new PropertyMetadata(false));

        private void CalculateTotalPrice()
        {
            if (!this.IsContentWrong)
            {
                try
                {
                    float Total, Quan, ItemPri, Disc;

                    if (!float.TryParse(this.Quantity, out Quan))
                    {
                        this.TotalPrice = "--.--";
                        return;
                    }

                    if (!float.TryParse(this.ItemPrice, out ItemPri))
                    {
                        this.TotalPrice = "--.--";
                        return;
                    }

                    if (!float.TryParse(this.Discount, out Disc))
                    {
                        this.TotalPrice = "--.--";
                        return;
                    }

                    Total = (ItemPri - Disc) * Quan;
                    this.TotalPrice = string.Format("{0:0.00}", Math.Round((double)Total, 2));
                }
                catch
                {
                    this.TotalPrice = "--.--";
                }
            }
            else
                this.TotalPrice = "--.--";
        }
    }
}
