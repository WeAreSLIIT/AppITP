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
            Products = this._unitOfWork.Products.Search(p => ProductIDs.Contains(p.ProductPublicID)).ToList();

            if (Products == null || Products.Count == 0 || InvoiceProductResources.Count != Products.Count)
                return null;

            ICollection<InvoiceProduct> InvoiceProducts = new List<InvoiceProduct>();

            foreach (InvoiceProductResource InvoiceProductResource in InvoiceProductResources)
            {
                if (InvoiceProductResource.Quantity <= 0)
                    return null;

                InvoiceProduct TempInvoiceProduct = new InvoiceProduct()
                {
                    ProductID = Products.FirstOrDefault(p => p.ProductPublicID == InvoiceProductResource.ID).ProductID,
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

                    //check payment methods are real and converte payment method name to PaymentMethod objects
                    ICollection<PaymentMethod> PaymentMethods = new List<PaymentMethod>();
                    PaymentMethods = new PaymentMethodControllerMethods(this._unitOfWork).MapPaymentMethodNamesToPaymentMethods(SentInvoiceResource.PaymentMethods);

                    if (PaymentMethods == null || PaymentMethods.Count == 0)
                        return null;

                    NewInvoice.PaymentMethods = PaymentMethods;

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
    }
}