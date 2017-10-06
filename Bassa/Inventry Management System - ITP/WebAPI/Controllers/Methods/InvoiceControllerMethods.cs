using DataAccess.Core;
using DataAccess.Core.Domain;
using System;
using System.Linq;
using System.Collections.Generic;
using WebAPI.Controllers.Resources;
using System.Threading.Tasks;
using WebAPI.Models;

namespace WebAPI.Controllers.Methods
{
    public class InvoiceControllerMethods
    {
        private IUnitOfWork _unitOfWork;

        public InvoiceControllerMethods(IUnitOfWork UnitOfWork)
        {
            this._unitOfWork = UnitOfWork;
        }

        public ICollection<InvoiceProduct> MapInvoiceProductResourcesToInvoiceProducts(ICollection<InvoiceProductResource> InvoiceProductResources)
        {
            if (InvoiceProductResources == null || InvoiceProductResources.Count == 0)
                return null;

            ICollection<string> ProductIDs = new List<string>();
            ProductIDs = InvoiceProductResources.Select(ipr => ipr.ID).ToList();

            ICollection<Product> Products = new List<Product>();
            Products = this._unitOfWork.Products.Search(p => ProductIDs.Contains(p.ProductPublicId)).ToList();

            if (Products == null || Products.Count == 0 || InvoiceProductResources.Count != Products.Count)
                return null;

            ICollection<InvoiceProduct> InvoiceProducts = new List<InvoiceProduct>();

            foreach (InvoiceProductResource InvoiceProductResource in InvoiceProductResources)
            {
                if (InvoiceProductResource.Quantity <= 0)
                    return null;

                InvoiceProduct TempInvoiceProduct = new InvoiceProduct()
                {
                    ProductID = Products.FirstOrDefault(p => p.ProductPublicId == InvoiceProductResource.ID).ProductId,
                    Quantity = InvoiceProductResource.Quantity
                };

                InvoiceProducts.Add(TempInvoiceProduct);
            }

            return InvoiceProducts;
        }

        public async Task<Invoice> MapCreateInvoiceResourceToInvoice(CreateInvoiceResource SentInvoiceResource)
        {
            Invoice ReturnInvoice = new Invoice();

            ReturnInvoice = await Task.Run(
                () =>
                {
                    //Check That SentInvoice is null
                    if (SentInvoiceResource == null)
                        return null;

                    //Check Counter is online and its real, if counter not online it will reject
                    bool? CounterStatus = true; // BackgroundProcess.CheckCounterIsOnline(SentInvoiceResource.Counter.BranchID, SentInvoiceResource.Counter.CouterNo);

                    if (CounterStatus == null || CounterStatus == false)
                        return null;

                    //Get Counter DB ID
                    long CounterID = (long)this._unitOfWork.Counters.GetCounterID(SentInvoiceResource.Counter.BranchID, SentInvoiceResource.Counter.CouterNo);

                    //Initialize NewInvoice
                    Invoice NewInvoice = new Invoice()
                    {
                        FullPayment = SentInvoiceResource.FullPayment,
                        Discount = SentInvoiceResource.Discount,
                        Payed = SentInvoiceResource.Payed,
                        Balance = SentInvoiceResource.Balance,
                        CounterID = CounterID
                    };

                    //check Time that sent by app
                    //if time is not given assign current time in server
                    if (SentInvoiceResource.Time == null || SentInvoiceResource.Time <= 0)
                        NewInvoice.Time = TimeConverterMethods.GetCurrentTimeInLong();
                    else
                        NewInvoice.Time = (long)SentInvoiceResource.Time;

                    //check Invoice issued employee exsits
                    if (this._unitOfWork.Employees.Get(SentInvoiceResource.IssuedBy) != null)
                        NewInvoice.IssuedByID = SentInvoiceResource.IssuedBy;
                    else
                        return null;

                    //check payment methods are real and convert payment method name to InvoicePaymentMethod objects
                    ICollection<InvoicePaymentMethod> InvoicePaymentMethods = new List<InvoicePaymentMethod>();
                    InvoicePaymentMethods = new InvoicePaymentMethodControllerMethods(this._unitOfWork).MapListInvoicePaymentMethodResourcesToListInvoicePaymentMethods(SentInvoiceResource.Payments);

                    if (InvoicePaymentMethods == null || InvoicePaymentMethods.Count == 0)
                        return null;

                    NewInvoice.InvoicePaymentMethods = InvoicePaymentMethods;

                    //check sende product are real and if it isn't reject
                    ICollection<InvoiceProduct> TempInvoiceProducts = new List<InvoiceProduct>();
                    TempInvoiceProducts = this.MapInvoiceProductResourcesToInvoiceProducts(SentInvoiceResource.Products.ToList());

                    if (TempInvoiceProducts == null || TempInvoiceProducts.Count == 0)
                        return null;

                    NewInvoice.InvoiceProducts = TempInvoiceProducts.ToList();

                    //validate public id sended
                    NewInvoice.InvoicePublicID = SentInvoiceResource.InvoiceId;
                    long CountInvoices = this._unitOfWork.Invoices.GetAllInvoicesCount();

                    string TempStringID = NewInvoice.InvoicePublicID;
                    Random Rand = new Random();

                    while (this._unitOfWork.Invoices.Get(NewInvoice.InvoicePublicID) != null)
                    {
                        NewInvoice.InvoicePublicID = TempStringID + "-sys" + (CountInvoices % 10000).ToString() + (Rand.Next(1, 99));
                    }

                    return NewInvoice;
                });

            return ReturnInvoice;
        }

        public InvoiceResource MapInvoiceToInvoiceResource(Invoice Invoice)
        {
            if (Invoice == null)
                return null;

            InvoiceResource InvoiceResource = new InvoiceResource()
            {
                InvoiceId = Invoice.InvoicePublicID,
                Time = Invoice.Time,
                FullPayment = Invoice.FullPayment,
                Discount = Invoice.Discount,
                Payed = Invoice.Payed,
                Balance = Invoice.Balance,
                IssuedBy = Invoice.IssuedByID,
                Counter = new CounterResource()
                {
                    BranchID = Invoice.Counter.BranchID,
                    CouterNo = Invoice.Counter.BranchCounterNo
                },
                PurchasedBy = Invoice.InvoiceCustomer == null ? (long?)null : Invoice.InvoiceCustomer.CustomerID,
                InvoiceDeal = Invoice.InvoiceDeal == null ? (long?)null : Invoice.InvoiceDeal.InvoiceDealDiscountID
            };

            foreach (InvoiceProduct InvoiceProduct in Invoice.InvoiceProducts)
            {
                InvoiceResource.Products.Add(
                    new InvoiceProductResource()
                    {
                        ID = InvoiceProduct.Product.ProductPublicId,
                        Quantity = InvoiceProduct.Quantity
                    });
            }

            foreach (InvoicePaymentMethod InvoicePaymentMethod in Invoice.InvoicePaymentMethods)
            {
                InvoiceResource.Payments.Add(
                    new InvoicePaymentMethodResource()
                    {
                        Method = InvoicePaymentMethod.PaymentMethod.PaymentMethodName,
                        Amount = InvoicePaymentMethod.Amount
                    });
            }

            return InvoiceResource;
        }

        public ICollection<InvoiceResource> MapListInvoiceToListInvoiceResource(ICollection<Invoice> Invoices)
        {
            if (Invoices == null || Invoices.Count == 0)
                return null;

            ICollection<InvoiceResource> InvoiceResources = new List<InvoiceResource>();

            foreach(Invoice Invoice in Invoices)
            {
                InvoiceResources.Add(this.MapInvoiceToInvoiceResource(Invoice));
            }

            return InvoiceResources;
        }
    }
}