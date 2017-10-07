using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccess.Core.Domain
{
    public class Log
    {
        [Key]
        public long LogID { get; set; }
        public long UserAccountID { get; set; }
        [ForeignKey("UserAccountID")]
        public UserAccount user { get; set; }
        public long ModuleID { get; set; }
        [ForeignKey("ModuleID")]
        public Module Module { get; set; }
        public string Activity { get; set; }

        public ICollection<Log> Logs { get; set; }

        public Log()
        {
            Logs = new HashSet<Log>();
        }
    }
}
