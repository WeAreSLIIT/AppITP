using Models.APICall;
using Models.Core;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;

namespace Models.Persistence
{
    public static class InventryMangementSystemDbContext
    {
        public static bool ConnectionCheckFirstTime;

        public static bool ConnectionToServer;
        public static string BaseAddressToServer;
        public static string AppID;

        public static ICollection<Product> Products;
        public static ICollection<PaymentMethod> PaymentMethods;
        public static ServerData ServerDateTime;
        public static SystemInfo SystemInformation;
        public static Counter CounterWorking;

        static InventryMangementSystemDbContext()
        {
            Products = new List<Product>();
            PaymentMethods = new List<PaymentMethod>();
            ServerDateTime = new ServerData();
            SystemInformation = new SystemInfo();
            CounterWorking = new Counter();

            ConnectionToServer = false;
            BaseAddressToServer = @"http://localhost:5556/";
            AppID = "csbwpfapp";
        }        

        public async static Task<bool> InitializeData()
        {
            try
            {
                #region Tempory Code until DB Connection

                #region Server Date Time



                #endregion

                #region Server Date Time



                #endregion

                #region Counter Working

                CounterWorking.BranchID = 1;
                CounterWorking.CouterNo = 1;

                #endregion

                #region Products

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

                #endregion

                #region PaymentMethods

                PaymentMethods.Add(new PaymentMethod()
                {
                    Name = "Cash",
                    Note = "Cash by hand"
                });

                PaymentMethods.Add(new PaymentMethod()
                {
                    Name = "Sampath-Credit",
                    Note = "Sampath Bank's Credit Card"
                });

                PaymentMethods.Add(new PaymentMethod()
                {
                    Name = "Commercial-Credit",
                    Note = "Commercial Bank's Credit Card"
                });

                #endregion

                #region Customers



                #endregion

                #endregion

                return true;
            }
            catch
            {
                return false;
            }
        }

        public async static Task<bool> CheckConnectionToServer()
        {
            return await new ServerConnectionAPICall().CheckServerStatus();
        }


    }
}
