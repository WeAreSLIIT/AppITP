using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Inventory_Management_System.Models
{
    public class SupplierPayment
    {
        public long SupplierPaymentID { set; get; }
        public string PaymentPublicID { set; get; }
        public double SupplierDeliverCost { set; get; }
        public long DueDate { set; get; }
        public long PayingDate { set; get; }
        public float subTotal { set; get; }
        public float TotalCost { set; get; }

    }
}