using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccess.Core.Domain
{
    public class UserRole
    {   
        [Key]
        public long UserRoleID { get; set; }
        public string Name { get; set; }
        public long AuthorizationLevel { get; set; }
        public string Description { get; set; }
        //[ForeignKey("PrivilegeID")]
        //public Privilege[] Privileges { get; set; }
        public bool Suspend { get; set; }

        public ICollection<Privilege> Privileges { get; set; }

        public UserRole()
        {
            Privileges = new HashSet<Privilege>();
        }
    }
}
