using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccess.Core.Domain
{

    public class UserAccount
    {   
        [Key]
        public long UserAccountID { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public long EmployeeID { get; set; }
        [ForeignKey("EmployeeID")]
        public Employee Employee { get; set; }
        public long UserRoleID { get; set; }
        [ForeignKey("UserRoleID")]
        public UserRole Role { get; set; }

        public ICollection<UserAccount> UserAccounts { get; set; }

        public UserAccount()
        {
            UserAccounts = new HashSet<UserAccount>();
        }
    }
}
