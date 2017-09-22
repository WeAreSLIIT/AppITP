using DataAccess.Core;
using DataAccess.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using WebAPI.Controllers.Resources;

namespace WebAPI.Controllers.Methods
{
    public class InvoiceControllerMethods
    {
        private IUnitOfWork _unitOfWork;

        public InvoiceControllerMethods(IUnitOfWork UnitOfWork)
        {
            this._unitOfWork = UnitOfWork;
        }

        public ICollection<InvoiceProduct> MapListInvoiceProductResourceToListInvoiceProduct(ICollection<InvoiceProductResource> InvoiceProductResources)
        {
            if (InvoiceProductResources == null || InvoiceProductResources.Count == 0)
                return null;

            ICollection<InvoiceProduct> InvoiceProducts = new List<InvoiceProduct>();
            bool Error = false;


            ICollection<long> ProductIDs = new List<long>();
            ProductIDs = InvoiceProductResources.Select(ipr => ipr.ProductID).ToList();

            ICollection<Product> Products = new List<Product>();

            if (ProductIDs == null || ProductIDs.Count == 0)
                Error = true;
            else
            {
                Products = this._unitOfWork.Products.Search(p => ProductIDs.Contains(p.ProductID)).ToList();

                if (Products == null || Products.Count == 0 || Products.Count != ProductIDs.Count)
                    Error = true;
            }

            if (!Error)
            {
                foreach (InvoiceProductResource InvoiceProductResource in InvoiceProductResources)
                {
                    InvoiceProduct TempInvoiceProduct = this.MapInvoiceProductResourceToInvoiceProduct(InvoiceProductResource);

                    InvoiceProducts.Add(TempInvoiceProduct);
                }
            }

            return (Error) ? null : InvoiceProducts;
        }

        public InvoiceProduct MapInvoiceProductResourceToInvoiceProduct(InvoiceProductResource InvoiceProductResource)
        {
            if (InvoiceProductResource.ProductID == 0 || InvoiceProductResource.Quantity == 0)
                return null;

            InvoiceProduct InvoiceProduct = new InvoiceProduct()
            {
                ProductID = InvoiceProductResource.ProductID,
                Quantity = InvoiceProductResource.Quantity
            };

            return InvoiceProduct;
        }

        public Invoice MapCreateInvoiceResourceToInvoice(CreateInvoiceResource CreateInvoiceResource)
        {
            if (CreateInvoiceResource == null)
                return null;

            Invoice NewInvoice = new Invoice()
            {
                InvoicePublicID = CreateInvoiceResource.InvoiceId,
                FullPayment = CreateInvoiceResource.FullPayment,
                Discount = CreateInvoiceResource.Discount,
                Payed = CreateInvoiceResource.Payed,
                Balance = CreateInvoiceResource.Balance
            };

            if (CreateInvoiceResource.Time == null || CreateInvoiceResource.Time <= 0)
                NewInvoice.Time = TimeConverterMethods.GetCurrentTimeInLong();
            else
                NewInvoice.Time = (long)CreateInvoiceResource.Time;

            if (this._unitOfWork.Employees.Get(CreateInvoiceResource.IssuedBy) != null)
                NewInvoice.IssuedByID = CreateInvoiceResource.IssuedBy;
            else
                return null;

            ICollection<InvoiceProduct> TempInvoiceProducts = new List<InvoiceProduct>(); // this.MapListInvoiceProductResourceToListInvoiceProduct(CreateInvoiceResource.Products);

            if (TempInvoiceProducts != null)
                NewInvoice.InvoiceProducts = TempInvoiceProducts;
            else
                return null;

            //if (new PaymentMethodControllerMethod(this._unitOfWork).ValidatePaymentMethodIDs(CreateInvoiceResource.PaymentMethods))
            //    NewInvoice.PaymentMethods = CreateInvoiceResource.PaymentMethods;

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