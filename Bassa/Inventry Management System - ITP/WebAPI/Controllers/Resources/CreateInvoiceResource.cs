using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebAPI.Controllers.Resources
{
    public class CreateInvoiceResource
    {
        [Required]
        [MaxLength(50)]
        public string InvoiceId { get; set; }
        
        public long? Time { get; set; }

        [Required]
        public float FullPayment { get; set; }
        [Required]
        public float Discount { get; set; }
        [Required]
        public float Payed { get; set; }
        [Required]
        public float Balance { get; set; }

        [Required]
        public long IssuedBy { get; set; }
        [Required]
        public long BranchID { get; set; }

        public long? PurchasedBy { get; set; }
        public long? InvoiceDeal { get; set; }

        [Required]
        public ICollection<string> Products { get; set; }
        [Required]
        public ICollection<string> PaymentMethods { get; set; }

        public CreateInvoiceResource()
        {
            Products = new HashSet<string>();
            PaymentMethods = new HashSet<string>();
        }
    }
}