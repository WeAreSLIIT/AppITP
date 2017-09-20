using DataAccess.Core;
using DataAccess.Core.Domain;
using DataAccess.Persistence;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebAPI.Controllers.Resources;

namespace WebAPI.Controllers.Mapping
{
    public class MappingsForInvoices
    {
        private IUnitOfWork _unitOfWork;

        public MappingsForInvoices()
        {
            this._unitOfWork = new UnitOfWork();
        }

        public async Task<List<InvoiceProduct>> ProductResourceToProduct(List<InvoiceProductResource> InvoiceProductResources)
        {
            if (InvoiceProductResources == null || InvoiceProductResources.Count == 0)
                return null;

            List<InvoiceProduct> InvoiceProducts = new List<InvoiceProduct>();

            await Task.Run(() =>
            {
                foreach (InvoiceProductResource InvoiceProductResource in InvoiceProductResources)
                {
                    this._unitOfWork.Products.Get(InvoiceProductResource.ProductID);
                }
            });
            
            return InvoiceProducts;
        }

        public Invoice CreateInvoiceResourceToInvoice(CreateInvoiceResource CreateInvoiceResource)
        {
            if (CreateInvoiceResource == null)
                return null;

            Invoice NewInvoice = new Invoice()
            {
                InvoicePublicID = CreateInvoiceResource.InvoiceId,
                Time = CreateInvoiceResource.Time,
                FullPayment = CreateInvoiceResource.FullPayment,
                Discount = CreateInvoiceResource.Discount,
                Payed = CreateInvoiceResource.Payed,
                Balance = CreateInvoiceResource.Balance,

                IssuedByID = CreateInvoiceResource.IssuedBy,
                IssuedBy = this._unitOfWork.Employees.Get(CreateInvoiceResource.IssuedBy)
            };



            /*
            public float FullPayment { get; set; }
            public float Discount { get; set; }
            public float Payed { get; set; }
            public float Balance { get; set; }

            public long IssuedByID { get; set; }
            public Employee IssuedBy { get; set; }

            public InvoiceCustomer InvoiceCustomer { get; set; }
            public InvoiceDeal InvoiceDeal { get; set; }

            public ICollection<InvoiceProduct> InvoiceProducts { get; set; }
            public ICollection<PaymentMethod> PaymentMethods { get; set; }
            */

            return NewInvoice;
        }
    }
}