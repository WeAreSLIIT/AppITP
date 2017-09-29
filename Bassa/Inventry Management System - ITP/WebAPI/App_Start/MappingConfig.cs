using DataAccess.Core.Domain;
using WebAPI.Controllers.Resources;
using System.Linq;
using DataAccess.Persistence.Repositories;
using DataAccess.Persistence;

namespace WebAPI.App_Start
{
    public static class AutoMappingConfig
    {
        public static void Configure()
        {
            //AutoMapper.Mapper.Initialize(config =>
            //{
            //    #region Domain Model to API Resources

            //    config.CreateMap<Invoice, CreateInvoiceResource>()
            //        .ForMember(dest => dest.InvoiceId, opt => opt.MapFrom(sour => sour.InvoicePublicID))
            //        .ForMember(dest => dest.IssuedBy, opt => opt.MapFrom(sour => sour.IssuedByID))
            //        .ForMember(dest => dest.PurchasedBy, opt => opt.MapFrom(sour => (sour.InvoiceCustomer == null) ? (long?)null : sour.InvoiceCustomer.CustomerID))
            //        .ForMember(dest => dest.InvoiceDeal, opt => opt.MapFrom(sour => (sour.InvoiceDeal == null) ? (long?)null : sour.InvoiceDeal.InvoiceDealDiscountID))
            //        .ForMember(dest => dest.Products, opt => opt.MapFrom(sour => sour.InvoiceProducts.Select(pro =>
            //                        new InvoiceProductResource() { ProductID = pro.ProductID, Quantity = pro.Quantity })));



            //    #endregion

            //    #region API Resources to Domain Model

            //    config.CreateMap<CreateInvoiceResource, Invoice>()
            //        .ForMember(dest => dest.InvoicePublicID, opt => opt.MapFrom(sour => sour.InvoiceId))
            //        .ForMember(dest => dest.IssuedByID, opt => opt.MapFrom(sour => sour.IssuedBy))
            //        .ForMember(dest => dest.InvoiceCustomer, opt => opt.MapFrom(sour => (sour.PurchasedBy == null) ? null : new InvoiceCustomer() { InvoiceID = (long)new UnitOfWork().Invoices.GetInvoiceID(sour.InvoiceId), CustomerID = (long)sour.PurchasedBy }))
            //        .ForMember(dest => dest.InvoiceDeal, opt => opt.MapFrom(sour => (sour.InvoiceDeal == null) ? null : new InvoiceDeal() { InvoiceID = (long)new UnitOfWork().Invoices.GetInvoiceID(sour.InvoiceId), InvoiceDealDiscountID = (long)sour.InvoiceDeal }))
            //        .ForMember(dest => dest.InvoiceProducts, opt => opt.MapFrom(sour => sour.Products.Select(ip =>
            //                        new InvoiceProduct { InvoiceID = (long)new UnitOfWork().Invoices.GetInvoiceID(sour.InvoiceId), ProductID = ip.ProductID, Quantity = ip.Quantity })));

            //    #endregion
            //});
        }
    }
}