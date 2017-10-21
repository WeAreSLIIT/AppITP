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
using System;

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
        public static Employee EmployeeWorking;

        //Invoice Syncing related variables
        private static bool UploadUnsyncInvoicesInProgress = false;
        public static bool IsThereUnsyncInvoices = false;
        private static bool FirstCheckUnsyncInvoices = false;


        static InventryMangementSystemDbContext()
        {
            Products = new List<Product>();
            PaymentMethods = new List<PaymentMethod>();
            TableVersions = new List<TableVersion>();
            ServerDateTime = new ServerData();
            SystemInformation = new SystemInfo();
            CounterWorking = new Counter();
            EmployeeWorking = new Employee();

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
                InventryMangementSystemDbContext.TableVersions.Clear();
                InventryMangementSystemDbContext.TableVersions = await new TableVersionAPICall().GetTableVersionData();

                await DoUpdatesRequired();

                await Task.Run(
                    () =>
                    {
                        ICollection<Product> TempProducts = DBConnection.GetProducts();

                        InventryMangementSystemDbContext.Products.Clear();
                        if (!(TempProducts == null || TempProducts.Count == 0))
                        {
                            InventryMangementSystemDbContext.Products = TempProducts;
                        }

                        ICollection<PaymentMethod> TempPaymentMethods = DBConnection.GetPaymentMethods();

                        InventryMangementSystemDbContext.PaymentMethods.Clear();
                        if (!(TempPaymentMethods == null || TempPaymentMethods.Count == 0))
                        {
                            InventryMangementSystemDbContext.PaymentMethods = TempPaymentMethods;
                        }
                    });
            }

            return ServerCheck;
        }

        public async static Task DoUpdatesRequired()
        {
            Debug.WriteLine("DoUpdatesRequired() called line 129");

            if (!(InventryMangementSystemDbContext.TableVersions == null ||
                InventryMangementSystemDbContext.TableVersions.Count == 0))
            {
                ICollection<TableVersion> TblVersions = DBConnection.GetTableVersions();

                foreach (TableVersion TableVersion in TblVersions)
                {
                    TableVersion NewTableVersion = InventryMangementSystemDbContext.TableVersions.FirstOrDefault(tv => tv.TableID == TableVersion.TableID);

                    if (NewTableVersion.Time > TableVersion.Time)
                    {
                        if (NewTableVersion.Table == DatabaseTable.Product)
                        {
                            ICollection<Product> Products = new List<Product>();
                            Products = await new ProductAPICall().CheckNewProducts();

                            DBConnection.UpdateProducts(Products);
                            Debug.WriteLine("DoUpdatesRequired() -> Products Table updated");
                        }
                        else if (NewTableVersion.Table == DatabaseTable.PaymentMethod)
                        {
                            ICollection<PaymentMethod> PaymentMethods = new List<PaymentMethod>();
                            PaymentMethods = await new PaymentMethodAPICall().CheckNewPaymentMethods();

                            DBConnection.UpdatePaymentMethods(PaymentMethods);
                            Debug.WriteLine("DoUpdatesRequired() -> PaymentMethods Table updated");
                        }

                        DBConnection.UpdateTableVersions(NewTableVersion.TableID, NewTableVersion.Time);
                    }
                }
            }
        }

        public async static Task<bool> AddNewInvoice(Invoice invoice)
        {
            return await Task.Run(
                () =>
                {
                    return DBConnection.AddNewInvoice(invoice);
                });
        }

        public static void UploadUnsyncInvoicesToServer(Action<bool, string> ProgressBarVisibity)
        {
            if (!FirstCheckUnsyncInvoices)
            {
                ICollection<Invoice> UnsyncInvoices = DBConnection.GetInvoices();
                if (UnsyncInvoices == null || UnsyncInvoices.Count == 0)
                {
                    IsThereUnsyncInvoices = false;
                }
                else
                {
                    IsThereUnsyncInvoices = true;
                }
                FirstCheckUnsyncInvoices = true;
            }

            if (ConnectionToServer && !UploadUnsyncInvoicesInProgress && IsThereUnsyncInvoices)
            {
                UploadUnsyncInvoicesInProgress = true;
                ProgressBarVisibity(true, "Uploading...");

                Thread UploadInvoicesToServerThread = new Thread(
                    async () =>
                    {
                        await UploadInvoicesToServer();

                        ProgressBarVisibity(false, "");
                        UploadUnsyncInvoicesInProgress = false;
                    });

                UploadInvoicesToServerThread.Start();                
            }
        }

        public async static Task<bool> UploadInvoicesToServer()
        {
            bool process = true;
            ICollection<Invoice> UnsyncInvoices = DBConnection.GetInvoices();

            if (!(UnsyncInvoices == null || UnsyncInvoices.Count == 0))
            {
                foreach (Invoice UnsyncInvoice in UnsyncInvoices)
                {
                    process = await UploadInvoiceToServer(UnsyncInvoice);

                    if (!process)
                        break;
                }
            }

            if (process)
                IsThereUnsyncInvoices = false;

            return process;
        }

        public async static Task<bool> UploadInvoiceToServer(Invoice invoice)
        {
            if (InventryMangementSystemDbContext.ConnectionToServer)
            {
                bool uploaded = await new InvoiceAPICall().SendInvoice(invoice);

                if (uploaded)
                {
                    await Task.Run(
                        () =>
                        {
                            if (uploaded)
                            {
                                DBConnection.DeleteInvoice(invoice.InvoiceId);
                            }
                        });
                }

                return uploaded;
            }
            else
                return false;
        }
    }
}
