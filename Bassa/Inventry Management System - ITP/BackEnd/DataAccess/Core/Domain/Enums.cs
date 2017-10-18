namespace DataAccess.Core.Domain
{
    //Dileepa
    public enum ExpireStatus
    {
        limited = 1,
        unlimited = 2
    }

    public enum Status : byte
    {
        redeemed = 1,
        issued = 2,
        expired = 3,
        renewed = 4
    }

    public enum DiscountMethod : byte
    {
        fixedPrice = 1,
        percentage = 2
    }

    //Harin's
    public enum ProductPriceType : byte
    {
        NormalPrice = 0,
        PackPrice,
        UnitPrice
    }

    //Yashika's
    public enum StockStatus : byte
    {
        FreeAndAvailable = 0,
        Recount = 1,
        Empty = 2
    }

    //CSB
    public enum DatabaseTable : byte
    {
        Product = 1,
        PaymentMethod
    }

    public enum Gender : byte
    {
        Female = 0,
        Male = 1
    }
    public enum Action : byte { CREATE, READ, UPDATE, DELETE, SUSPEND, ACTIVE };

}
