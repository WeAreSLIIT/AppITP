using System.Collections.Generic;

namespace DataAccess.Core.Domain
{
    public class Product
    {
        public long ProductID { get; private set; }
        public string ProductName { get; set; }

        public ICollection<InvoiceProduct> InvoiceProducts { get; set; }

        public Product()
        {
            InvoiceProducts = new HashSet<InvoiceProduct>();
        }
    }
}
