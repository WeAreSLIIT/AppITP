namespace WebAPI.Controllers.Resources
{
    public enum DiscountMethodResource : byte
    {
        Price = 0,
        Percentage
    }

    public enum ProductPriceType : byte
    {
        NormalPrice = 0,
        PackPrice,
        UnitPrice
    }
}