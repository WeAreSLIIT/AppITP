using DataAccess.Core.Domain;
using WebAPI.Controllers.Resources;
using System.Linq;

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
                    .ForMember(dest => dest.InvoiceId, opt => opt.MapFrom(sour => sour.PublicID));

                #endregion

                #region API Resources to Domain Model

                config.CreateMap<InvoiceResource, Invoice>()
                    .ForMember(dest => dest.PublicID, opt => opt.MapFrom(sour => sour.InvoiceId))
                    .ForMember(dest => dest.InvoiceProducts, opt => opt.MapFrom(sour => sour.Products.Select(id => new InvoiceProduct { ProductID = id })));

                #endregion
            });
        }
    }
}