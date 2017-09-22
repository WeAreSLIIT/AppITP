using System.Collections.Generic;

namespace DataAccess.Core.Domain
{
    public class Branch
    {
        public long BranchID { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }

        public ICollection<Counter> Counters { get; set; }

        public Branch()
        {
            Counters = new HashSet<Counter>();
        }
    }
}
