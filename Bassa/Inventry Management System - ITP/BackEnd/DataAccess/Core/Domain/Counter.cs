using System.Collections.Generic;

namespace DataAccess.Core.Domain
{
    public class Counter
    {
        public long CounterID { get; set; }
        public long BranchCounterNo { get; set; }

        public long BranchID { get; set; }
        public Branch Branch { get; set; }

        public ICollection<Invoice> Invoices { get; set; }

        public bool Online { get; set; }

        public Counter()
        {
            Invoices = new HashSet<Invoice>();
            Online = false;
        }
    }
}
