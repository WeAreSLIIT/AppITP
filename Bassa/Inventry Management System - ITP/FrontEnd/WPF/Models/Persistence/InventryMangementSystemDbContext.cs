using Models.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Models.Persistence
{
    public static class InventryMangementSystemDbContext
    {
        public static ICollection<Product> Products;

        static InventryMangementSystemDbContext()
        {
            Products = new List<Product>();
        }

        public static bool InitializeData()
        {
            try
            {
                Products.Add(new Product()
                {
                    ID = "001-1-1",
                    Name = "Biscut Gold Maree",
                    Bracode = "11111111111",
                    Price = 100,
                    Type = ProductType.Unit
                });

                Products.Add(new Product()
                {
                    ID = "001-12",
                    Name = "Biscut Chocolate",
                    Bracode = "11111111112",
                    Price = 100,
                    Type = ProductType.Unit
                });

                Products.Add(new Product()
                {
                    ID = "001-1-3",
                    Name = "Kandos Chocolate",
                    Bracode = "11111111113",
                    Price = 100,
                    Type = ProductType.Measurable
                });

                Products.Add(new Product()
                {
                    ID = "001-1-4",
                    Name = "Pudin",
                    Bracode = "11111111114",
                    Price = 100,
                    Type = ProductType.Measurable
                });

                Products.Add(new Product()
                {
                    ID = "001-1-5",
                    Name = "Apple",
                    Bracode = "11111111115",
                    Price = 100,
                    Type = ProductType.Unit
                });

                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
