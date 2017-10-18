using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DataAccess.Core.Domain
{
    public class Branch
    {   
        [Key]
        public long BranchID { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public string BranchTitle { get; set; }
        public double Longtitude { get; set; }
        public double Latitude { get; set; }
        public int BranchLevel { get; set; }
        public string Address { get; set; }
        public string[] ContactNumbers { get; set; }
        public string Email { get; set; }

       
        public ICollection<Counter> Counters { get; set; }

        public Branch()
        {
            Counters = new HashSet<Counter>();
            
        }
    }
}
