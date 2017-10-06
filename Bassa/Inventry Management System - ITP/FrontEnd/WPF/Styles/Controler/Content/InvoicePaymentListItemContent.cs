using System;
using System.Windows;
using System.Windows.Controls;

namespace Styles.Controler
{
    public class InvoicePaymentListItemContent : ContentControl
    {
        static InvoicePaymentListItemContent() { }
        

        public string PaymentMethodName
        {
            get { return (string)GetValue(PaymentMethodNameProperty); }
            set { SetValue(PaymentMethodNameProperty, value); }
        }

        public static readonly DependencyProperty PaymentMethodNameProperty =
            DependencyProperty.Register("PaymentMethodName", typeof(string), typeof(InvoicePaymentListItemContent), new PropertyMetadata("Payment ###"));
        

        public string PaymentAmount
        {
            get { return (string)GetValue(PaymentAmountProperty); }
            set { SetValue(PaymentAmountProperty, value); }
        }

        public static readonly DependencyProperty PaymentAmountProperty =
            DependencyProperty.Register("PaymentAmount", typeof(string), typeof(InvoicePaymentListItemContent),
                new PropertyMetadata("0.00",
                    (sender, e) =>
                    {
                        InvoicePaymentListItemContent Sender = sender as InvoicePaymentListItemContent;

                        float f;
                        if (float.TryParse(Sender.PaymentAmount, out f))
                            Sender.IsContentWrong = false;
                        else
                            Sender.IsContentWrong = true;
                    }));



        public bool IsNotify
        {
            get { return (bool)GetValue(IsNotifyProperty); }
            set { SetValue(IsNotifyProperty, value); }
        }

        public static readonly DependencyProperty IsNotifyProperty =
            DependencyProperty.Register("IsNotify", typeof(bool), typeof(InvoicePaymentListItemContent), new PropertyMetadata(false));

        public bool IsContentWrong
        {
            get { return (bool)GetValue(IsContentWrongProperty); }
            private set { SetValue(IsContentWrongProperty, value); }
        }

        public static readonly DependencyProperty IsContentWrongProperty =
            DependencyProperty.Register("IsContentWrong", typeof(bool), typeof(InvoicePaymentListItemContent), new PropertyMetadata(false));
    }
}
