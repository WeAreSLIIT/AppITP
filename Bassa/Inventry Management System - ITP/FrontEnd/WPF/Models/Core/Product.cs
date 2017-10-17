namespace Models.Core
{
    public class Product
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public string Bracode { get; set; }
        public float Price { get; set; }
        public ProductType Type { get; set; }
    }
}
