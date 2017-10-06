namespace DataAccess.Core.Domain
{
    public enum DiscountMethod : byte
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
