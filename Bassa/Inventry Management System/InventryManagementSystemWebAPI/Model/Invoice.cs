using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InventryManagementSystemWebAPI.Model
{
    public class Invoice
    {
        public long InvoiceID { get; set; }
        public DateTime IssueDate { get; set; }
        public float Amount { get; set; }
        public string InvoicePublicID { get; set; }

        public List<Product> Products { get; set; }

        public List<PaymentMethod> PaymentMethods { get; set; }

        public Employee IssedBy { get; set; }
        public Customer IssedTo { get; set; }
    }

    public class Customer
    {

    }

    public class Employee
    {

    }

    public class Product
    {

    }
}