using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace DataAccess.Core.Domain
{
    public class Privilege
    {   
        [Key]
        public long PrivilegeID { get; set; }
        public long ModuleID { get; set; }
        [ForeignKey("ModuleID")]
        public Module Module { get; set; }
        public Action[] Actions { get; set; }

   

        public Privilege()
        {
            
        }
    }
}
