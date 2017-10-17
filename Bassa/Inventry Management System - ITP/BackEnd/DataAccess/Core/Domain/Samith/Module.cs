using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DataAccess.Core.Domain
{
    public class Module
    {   
        [Key]
        public long ModuleID { get; set; }
        public string Name { get; set; }
        public string Route { get; set; }
        public string Description { get; set; }
        public bool Suspend { get; set; }
        public bool Active { get; set; }
        
        public Module()
        {
           
        }
    }
}
