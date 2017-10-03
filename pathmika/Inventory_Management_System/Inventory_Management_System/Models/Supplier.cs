using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Inventory_Management_System.Models
{
    public class Supplier
    {
        public long SupplierID { set; get; }
        public string  PublicSupplierID{ set; get; }
        public string FirstName { set; get; }
        public string LastName { set; get; }
        public int tel { set; get; }
        public string email { set; get; }
        public string suppliedtype { set; get; }
        public string companyName { set; get; }
        public string companyAddress { set; get; }
        public int companyPhone { set; get; }
        public long AddedDate { set; get; }
    }
}