using Models.ADO;
using Models.APICall;
using Models.Core;
using System.Linq;
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
        public static ICollection<TableVersion> TableVersions;
        public static ServerData ServerDateTime;
        public static SystemInfo SystemInformation;
        public static Counter CounterWorking;

        static InventryMangementSystemDbContext()
        {
            Products = new List<Product>();
            PaymentMethods = new List<PaymentMethod>();
            TableVersions = new List<TableVersion>();
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
                CounterWorking.BranchID = 1;
                CounterWorking.CouterNo = 1;

                bool check = await CheckConnectionToServer();


                if (check)
                {
                    await Task.Run(() =>
                    {
                        #region Products

                        Products.Clear();
                        Products = DBConnection.GetProducts();

                        #endregion

                        #region PaymentMethods

                        PaymentMethods.Clear();
                        PaymentMethods = DBConnection.GetPaymentMethods();

                        #endregion
                    });

                    #region Tempory Code until DB Connection

                    CounterWorking.BranchID = 1;
                    CounterWorking.CouterNo = 1;

                    #endregion


                    return true;
                }
                else
                    return false;
            }
            catch
            {
                return false;
            }
        }

        public async static Task<bool> CheckConnectionToServer()
        {
            bool ServerCheck = await new ServerConnectionAPICall().CheckServerStatus();

            if (ServerCheck)
            {
                ICollection<TableVersion> TableVersions = new List<TableVersion>();
                TableVersions = await new TableVersionAPICall().GetTableVersionData();

                DoUpdatesRequired(TableVersions);

                //ICollection<Product> TempProducts = DBConnection.GetProducts();

                //if (!(TempProducts == null || TempProducts.Count == 0))
                //{
                //    Products.Clear();

                //    foreach (Product TempProduct in TempProducts)
                //    {
                //        Products.Add(TempProduct);
                //    }
                //}

                //ICollection<PaymentMethod> TempPaymentMethods = DBConnection.GetPaymentMethods();

                //if (!(TempPaymentMethods == null || TempPaymentMethods.Count == 0))
                //{
                //    PaymentMethods.Clear();

                //    PaymentMethods = TempPaymentMethods;
                //}
            }

            return ServerCheck;
        }

        public async static void DoUpdatesRequired(ICollection<TableVersion> NewTableVersions)
        {
            if (!(TableVersions == null || TableVersions.Count == 0))
            {
                ICollection<TableVersion> TableVersions = DBConnection.GetTableVersions();

                foreach (TableVersion TableVersion in TableVersions)
                {
                    TableVersion NewTableVersion = NewTableVersions.FirstOrDefault(tv => tv.TableID == TableVersion.TableID);

                    if (NewTableVersion.Time > TableVersion.Time)
                    {
                        if (NewTableVersion.Table == DatabaseTable.Product)
                        {
                            ICollection<Product> Products = new List<Product>();
                            Products = await new ProductAPICall().CheckNewProducts();
                            Debug.WriteLine("WPF -> Products");

                            DBConnection.UpdateProducts(Products);
                        }
                        else if (NewTableVersion.Table == DatabaseTable.PaymentMethod)
                        {
                            ICollection<PaymentMethod> PaymentMethods = new List<PaymentMethod>();
                            PaymentMethods = await new PaymentMethodAPICall().CheckNewPaymentMethods();
                            Debug.WriteLine("WPF -> Products");

                            DBConnection.UpdatePaymentMethods(PaymentMethods);
                        }

                        DBConnection.UpdateTableVersions(TableVersion.TableID, TableVersion.Time);
                    }
                }
            }
        }
    }
}
