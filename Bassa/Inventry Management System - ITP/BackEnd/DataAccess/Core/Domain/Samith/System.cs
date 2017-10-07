using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccess.Core.Domain
{
    public class SystemDetails
    {   
        [Key]
        public long SystemDetailsID { get; set; }
        public string CompanyName { get; set; }
        public string Logo { get; set; }
        public string Description { get; set; }
        public long BranchID { get; set; }
        [ForeignKey("BranchID")]
        public Branch HeadOffice { get; set; }


        public SystemDetails()
        {
           
        }
    }
}
