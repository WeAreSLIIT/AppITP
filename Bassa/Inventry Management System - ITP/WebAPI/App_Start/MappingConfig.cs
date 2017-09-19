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
            AutoMapper.Mapper.Initialize(config =>
            {
                #region Domain Model to API Resources

                config.CreateMap<Invoice, InvoiceResource>()
                    .ForMember(dest => dest.InvoiceId, opt => opt.MapFrom(sour => sour.PublicID))
                    .ForMember(dest => dest.IssuedBy, opt => opt.MapFrom(sour => sour.IssuedByID))
                    .ForMember(dest => dest.PurchasedBy, opt => opt.MapFrom(sour => (sour.InvoiceCustomer == null) ? (long?)null : sour.InvoiceCustomer.CustomerID))
                    .ForMember(dest => dest.InvoiceDeal, opt => opt.MapFrom(sour => (sour.InvoiceDeal == null) ? (long?)null : sour.InvoiceDeal.InvoiceDealDiscountID))
                    .ForMember(dest => dest.Products, opt => opt.MapFrom(sour => sour.InvoiceProducts.Select(pro => 
                                    new InvoiceProductResource() { ProductID = pro.ProductID, Quantity = pro.Quantity })));

                #endregion

                #region API Resources to Domain Model

                config.CreateMap<InvoiceResource, Invoice>()
                    .ForMember(dest => dest.PublicID, opt => opt.MapFrom(sour => sour.InvoiceId))
                    .ForMember(dest => dest.IssuedByID, opt => opt.MapFrom(sour => sour.IssuedBy))
                    .ForMember(dest => dest.InvoiceCustomer, opt => opt.MapFrom(sour => sour.PurchasedBy == null ? null :
                                    new UnitOfWork().InvoiceCustomers.Get(sour.InvoiceId, (long)sour.PurchasedBy)))
                    .ForMember(dest => dest.InvoiceDeal, opt => opt.MapFrom(sour => sour.InvoiceDeal == null ? null : new InvoiceDeal() { InvoiceDealDiscountID = (long)sour.InvoiceDeal}))
                    .ForMember(dest => dest.InvoiceProducts, opt => opt.MapFrom(sour => sour.Products.Select(ip => 
                                    new InvoiceProduct { ProductID = ip.ProductID, Quantity = ip.Quantity })));

                #endregion
            });
        }
    }
}