using Models.Core;
using Models.Persistence;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SQLite;
using System.Diagnostics;
using System.IO;

namespace Models.ADO
{
    public static class DBConnection
    {
        private readonly static string _dbFileName = "data.dat";
        private readonly static string _password = "pass";

        private static SQLiteConnection _conn;

        private static string LocalDBCSNoPW =
            ConfigurationManager.ConnectionStrings["LocalDBCSNoPW"].ConnectionString;
        private static string LocalDBCSWithPW =
            ConfigurationManager.ConnectionStrings["LocalDBCSNoPW"].ConnectionString;
        //private static string LocalDBCSWithPW =
        //ConfigurationManager.ConnectionStrings["LocalDBCSWithPW"].ConnectionString;

        public static bool IsThisFirstTime()
        {
            return !File.Exists(_dbFileName);
        }

        #region Database Connection

        private static SQLiteConnection OpenDBConnection()
        {
            try
            {
                if (!File.Exists(_dbFileName))
                {
                    SQLiteConnection.CreateFile(_dbFileName);
                    using (SQLiteConnection Conn = new SQLiteConnection(LocalDBCSNoPW))
                    {
                        Conn.Open();
                        //Conn.ChangePassword(_password);
                        Console.WriteLine("OpenDBConnection() -> Database Created.");
                    }

                    using (SQLiteConnection Conn = new SQLiteConnection(LocalDBCSWithPW))
                    {
                        Conn.Open();
                        using (SQLiteCommand sqliteCommand = new SQLiteCommand())
                        {
                            sqliteCommand.Connection = Conn;

                            #region Create Tables

                            //sqliteCommand.CommandText = "CREATE TABLE `Employees` (`ID` TEXT, `Name` TEXT, PRIMARY KEY(`ID`))";
                            //sqliteCommand.ExecuteNonQuery();
                            //Debug.WriteLine("WPF -> Employees Table Created.");

                            sqliteCommand.CommandText = "CREATE TABLE `Invoices` (`InvoiceId` TEXT NOT NULL," +
                                "`Time` INTEGER NOT NULL,`FullPayment` REAL NOT NULL,`Discount` REAL NOT NULL,`Payed` REAL NOT NULL," +
                                "`Balance` REAL NOT NULL,`IssuedBy` INTEGER NOT NULL,`PurchasedBy` INTEGER,`InvoiceDeal` INTEGER," +
                                "`BranchID` INTEGER, `CouterNo` INTEGER,PRIMARY KEY(`InvoiceId`))";//`Sync`	INTEGER NOT NULL DEFAULT 0,
                            sqliteCommand.ExecuteNonQuery();
                            Debug.WriteLine("WPF -> Invoices Table Created.");

                            sqliteCommand.CommandText = "CREATE TABLE `InvoiceProducts` (`ID` TEXT NOT NULL,`Quantity` INTEGER NOT NULL," +
                                "`InvoiceId` TEXT NOT NULL, PRIMARY KEY(`ID`,`InvoiceId`))";
                            sqliteCommand.ExecuteNonQuery();
                            Debug.WriteLine("WPF -> InvoiceProducts Table Created.");

                            sqliteCommand.CommandText = "CREATE TABLE `InvoicePaymentMethods` (`Method` TEXT NOT NULL,`Amount` REAL NOT NULL," +
                                "`InvoiceId` TEXT NOT NULL,PRIMARY KEY(`Method`,`InvoiceId`))";
                            sqliteCommand.ExecuteNonQuery();
                            Debug.WriteLine("WPF -> InvoicePaymentMethods Table Created.");

                            sqliteCommand.CommandText = "CREATE TABLE `Products` (`ID` TEXT, `Name` TEXT, `Barcode` INTEGER, `Type` INTEGER, `Price` NUMERIC, PRIMARY KEY(`ID`))";
                            sqliteCommand.ExecuteNonQuery();
                            Debug.WriteLine("OpenDBConnection() -> Products Table Created.");

                            sqliteCommand.CommandText = "CREATE TABLE `PaymentMethods` (`Name` TEXT, `Note` TEXT, PRIMARY KEY(`Name`))";
                            sqliteCommand.ExecuteNonQuery();
                            Debug.WriteLine("OpenDBConnection() -> PaymentMethods Table Created.");

                            sqliteCommand.CommandText = "CREATE TABLE `TableVersions` (`TableID` INTEGER NOT NULL, `Version` INTEGER NOT NULL, PRIMARY KEY(`TableID`))";
                            sqliteCommand.ExecuteNonQuery();
                            Debug.WriteLine("OpenDBConnection() -> Versions Table Created.");

                            sqliteCommand.CommandText = "CREATE TABLE `TableNumbers` (`TableID` INTEGER NOT NULL, `CountingDate` INTEGER NOT NULL, `RowCount` INTEGER NOT NULL, PRIMARY KEY(`TableID`))";
                            sqliteCommand.ExecuteNonQuery();
                            Debug.WriteLine("OpenDBConnection() -> Numbers Table Created.");

                            #endregion

                            #region Seed Tables

                            sqliteCommand.CommandText = "INSERT INTO `TableVersions`(`TableID`,`Version`) values (@TableID, @Version)";
                            sqliteCommand.Parameters.AddWithValue("@TableID", "1");
                            sqliteCommand.Parameters.AddWithValue("@Version", "0");
                            sqliteCommand.ExecuteNonQuery();

                            sqliteCommand.Parameters.AddWithValue("@TableID", "2");
                            sqliteCommand.Parameters.AddWithValue("@Version", "0");
                            sqliteCommand.ExecuteNonQuery();

                            Debug.WriteLine("OpenDBConnection() -> Versions Table Seeded.");

                            sqliteCommand.CommandText = "INSERT INTO `TableNumbers`(`TableID`, `CountingDate`, `RowCount`) values (@TableID, @CountingDate, @RowCount)";
                            sqliteCommand.Parameters.AddWithValue("@TableID", "3");
                            sqliteCommand.Parameters.AddWithValue("@CountingDate", TimeConverterMethods.GetCurrentDateInLong().ToString());
                            sqliteCommand.Parameters.AddWithValue("@RowCount", "0");
                            sqliteCommand.ExecuteNonQuery();

                            Debug.WriteLine("OpenDBConnection() -> Numbers Table Seeded.");

                            #endregion
                        }
                    }
                }

                _conn = new SQLiteConnection(LocalDBCSWithPW);

                return _conn;
            }
            catch (Exception ex)
            {
                Debug.WriteLine("OpenDBConnection() -> " + ex.ToString());
                return null;
            }
        }

        #endregion

        #region Table Version

        public static ICollection<TableVersion> GetTableVersions()
        {
            ICollection<TableVersion> TableVersions = new List<TableVersion>();

            Debug.WriteLine($"GetTableVersions() called");
            try
            {
                using (SQLiteConnection Conn = OpenDBConnection())
                {
                    Conn.Open();

                    using (SQLiteCommand cmd = new SQLiteCommand("Select * from TableVersions", Conn))
                    {
                        using (SQLiteDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                TableVersion TableVersion = new TableVersion();

                                TableVersion.Table = (DatabaseTable)(Convert.ToByte(reader["TableID"].ToString()));
                                TableVersion.Time = Convert.ToInt64(reader["Version"].ToString());

                                TableVersions.Add(TableVersion);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("GetTableVersions() -> " + ex.ToString());
            }

            return TableVersions;
        }

        #endregion

        #region Table Numbers

        public static int GetRowCount(DatabaseTable Table)
        {
            try
            {
                using (SQLiteConnection Conn = OpenDBConnection())
                {
                    Conn.Open();

                    using (SQLiteCommand cmd = new SQLiteCommand())
                    {
                        cmd.Connection = Conn;
                        cmd.CommandText = "select * from TableNumbers Where `TableID` = @TableID";
                        cmd.Parameters.AddWithValue("@TableID", (byte)(Table));

                        using (SQLiteDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                long TableDate = Convert.ToInt64(reader["CountingDate"].ToString());

                                Debug.WriteLine($"Table Date = {TableDate}, System Date = {TimeConverterMethods.GetCurrentDateInLong()}");

                                if (TableDate == TimeConverterMethods.GetCurrentDateInLong())
                                {
                                    int RowCount = Convert.ToInt32(reader["RowCount"].ToString());
                                    return RowCount;
                                }
                                else
                                {
                                    if (ResetRowCount(Table, Conn))
                                        return 0;
                                    else
                                        return -1;
                                }
                            }
                            else
                                return -1;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("GetRowCount() -> " + ex.ToString());
                return -1;
            }
        }

        private static bool ResetRowCount(DatabaseTable Table, SQLiteConnection Conn)
        {
            try
            {
                using (Conn)
                {
                    using (SQLiteCommand cmd = new SQLiteCommand())
                    {
                        if (Conn.State != System.Data.ConnectionState.Open)
                            Conn.Open();

                        cmd.Connection = Conn;
                        cmd.CommandText = "UPDATE `TableNumbers` SET `CountingDate` = @CountingDate, `RowCount` = @RowCount Where `TableID` = @TableID";
                        cmd.Parameters.AddWithValue("@CountingDate", TimeConverterMethods.GetCurrentDateInLong());
                        cmd.Parameters.AddWithValue("@TableID", (byte)(Table));
                        cmd.Parameters.AddWithValue("@RowCount", 0);

                        int changesCount = cmd.ExecuteNonQuery();

                        return (changesCount > 0);
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("ResetRowCount() -> " + ex.ToString());
                return false;
            }
        }

        private static bool IncrementRowCount(DatabaseTable Table, SQLiteConnection Conn)
        {
            try
            {
                using (Conn)
                {
                    using (SQLiteCommand cmd = new SQLiteCommand())
                    {
                        if (Conn.State != System.Data.ConnectionState.Open)
                            Conn.Open();

                        cmd.Connection = Conn;

                        cmd.CommandText = "select `RowCount` from TableNumbers Where `TableID` = @TableID";
                        cmd.Parameters.AddWithValue("@TableID", (byte)(Table));
                        int RowCount = Convert.ToInt32(cmd.ExecuteScalar().ToString()) + 1;

                        cmd.CommandText = "UPDATE `TableNumbers` SET `RowCount` = @RowCount Where `TableID` = @TableID";
                        cmd.Parameters.AddWithValue("@RowCount", RowCount);
                        cmd.Parameters.AddWithValue("@TableID", (byte)(Table));

                        int changesCount = cmd.ExecuteNonQuery();

                        return (changesCount > 0);
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("IncrementRowCount() -> " + ex.ToString());
                return false;
            }
        }

        #endregion

        #region Invoice

        public static bool DeleteInvoice(string InvoiceId)
        {
            try
            {
                using (SQLiteConnection Conn = OpenDBConnection())
                {
                    Conn.Open();

                    using (SQLiteTransaction Transaction = Conn.BeginTransaction())
                    {
                        SQLiteCommand cmd = new SQLiteCommand();
                        cmd.Connection = Conn;
                        cmd.CommandText = "delete from Invoices where InvoiceId = @InvoiceId";
                        cmd.Parameters.AddWithValue("@InvoiceId", InvoiceId);

                        int deleteRow = cmd.ExecuteNonQuery();

                        if (deleteRow > 0)
                        {
                            cmd.CommandText = "delete from InvoiceProducts where InvoiceId = @InvoiceId";
                            cmd.Parameters.AddWithValue("@InvoiceId", InvoiceId);
                            cmd.ExecuteNonQuery();

                            cmd.CommandText = "delete from InvoicePaymentMethods where InvoiceId = @InvoiceId";
                            cmd.Parameters.AddWithValue("@InvoiceId", InvoiceId);
                            cmd.ExecuteNonQuery();
                        }

                        Transaction.Commit();

                        if (deleteRow > 0)
                        {
                            Debug.WriteLine($"DeleteInvoice() -> Invoice Deleted");
                            return true;
                        }
                        else
                        {
                            Debug.WriteLine($"DeleteInvoice() -> Invoice not Deleted");
                            return false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"DeleteInvoice() -> {ex.ToString()}");
                return false;
            }
        }

        public static ICollection<Invoice> GetInvoices()
        {
            ICollection<Invoice> ReturnInvoices = new List<Invoice>();

            try
            {
                using (SQLiteConnection Conn = OpenDBConnection())
                {
                    Conn.Open();

                    SQLiteCommand cmdInvoice = new SQLiteCommand();
                    cmdInvoice.Connection = Conn;
                    cmdInvoice.CommandText = "select * from Invoices";

                    SQLiteCommand cmdInvoiceProduct = new SQLiteCommand();
                    cmdInvoiceProduct.Connection = Conn;
                    cmdInvoiceProduct.CommandText = "select * from InvoiceProducts where InvoiceId = @InvoiceId";

                    SQLiteCommand cmdInvoicePayment = new SQLiteCommand();
                    cmdInvoicePayment.Connection = Conn;
                    cmdInvoicePayment.CommandText = "select * from InvoicePaymentMethods where InvoiceId = @InvoiceId";

                    using (SQLiteDataReader readerInvoice = cmdInvoice.ExecuteReader())
                    {
                        while (readerInvoice.Read())
                        {
                            Invoice ReturnInvoice = new Invoice();

                            ReturnInvoice.InvoiceId = readerInvoice["InvoiceId"].ToString();
                            ReturnInvoice.Time = Convert.ToInt64(readerInvoice["Time"].ToString());
                            ReturnInvoice.FullPayment = float.Parse(readerInvoice["FullPayment"].ToString());
                            ReturnInvoice.Discount = float.Parse(readerInvoice["Discount"].ToString());
                            ReturnInvoice.Payed = float.Parse(readerInvoice["Payed"].ToString());
                            ReturnInvoice.Balance = float.Parse(readerInvoice["Balance"].ToString());
                            ReturnInvoice.IssuedBy = Convert.ToInt64(readerInvoice["IssuedBy"].ToString());
                            ReturnInvoice.InvoiceDeal = (String.IsNullOrEmpty(readerInvoice["InvoiceDeal"].ToString())) ? (long?)null : Convert.ToInt64(readerInvoice["InvoiceDeal"].ToString());

                            ReturnInvoice.Counter = new Counter()
                            {
                                BranchID = Convert.ToInt64(readerInvoice["BranchID"].ToString()),
                                CouterNo = Convert.ToInt64(readerInvoice["CouterNo"].ToString())
                            };

                            cmdInvoiceProduct.Parameters.AddWithValue("@InvoiceId", ReturnInvoice.InvoiceId);

                            using (SQLiteDataReader readerInvoiceProduct = cmdInvoiceProduct.ExecuteReader())
                            {
                                ReturnInvoice.Products = new List<InvoiceProduct>();
                                while (readerInvoiceProduct.Read())
                                {
                                    ReturnInvoice.Products.Add(
                                        new InvoiceProduct()
                                        {
                                            ID = readerInvoiceProduct["ID"].ToString(),
                                            Quantity = float.Parse(readerInvoiceProduct["Quantity"].ToString())
                                        });
                                }
                            }

                            cmdInvoicePayment.Parameters.AddWithValue("@InvoiceId", ReturnInvoice.InvoiceId);
                            using (SQLiteDataReader readerInvoicePayment = cmdInvoicePayment.ExecuteReader())
                            {
                                ReturnInvoice.Payments = new List<InvoicePaymentMethod>();
                                while (readerInvoicePayment.Read())
                                {
                                    ReturnInvoice.Payments.Add(
                                        new InvoicePaymentMethod()
                                        {
                                            Method = readerInvoicePayment["Method"].ToString(),
                                            Amount = float.Parse(readerInvoicePayment["Amount"].ToString())
                                        });
                                }
                            }

                            ReturnInvoices.Add(ReturnInvoice);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("GetInvoices() -> " + ex.ToString());
            }

            return ReturnInvoices;
        }

        public static bool AddNewInvoice(Invoice NewInvoice)
        {
            try
            {
                using (SQLiteConnection Conn = OpenDBConnection())
                {
                    Conn.Open();

                    SQLiteCommand cmd = new SQLiteCommand();
                    cmd.Connection = Conn;

                    using (SQLiteTransaction Transaction = Conn.BeginTransaction())
                    {
                        cmd.CommandText = "INSERT INTO `Invoices`(`InvoiceId`,`Time`,`FullPayment`,`Discount`,`Payed`,`Balance`,`IssuedBy`,`PurchasedBy`,`InvoiceDeal`,`BranchID`,`CouterNo`) " +
                        "VALUES(@InvoiceId,@Time,@FullPayment,@Discount,@Payed,@Balance,@IssuedBy,@PurchasedBy,@InvoiceDeal,@BranchID,@CouterNo)";
                        cmd.Parameters.AddWithValue("@InvoiceId", NewInvoice.InvoiceId);
                        cmd.Parameters.AddWithValue("@Time", NewInvoice.Time);
                        cmd.Parameters.AddWithValue("@FullPayment", NewInvoice.FullPayment);
                        cmd.Parameters.AddWithValue("@Discount", NewInvoice.Discount);
                        cmd.Parameters.AddWithValue("@Payed", NewInvoice.Payed);
                        cmd.Parameters.AddWithValue("@Balance", NewInvoice.Balance);
                        cmd.Parameters.AddWithValue("@IssuedBy", NewInvoice.IssuedBy);
                        cmd.Parameters.AddWithValue("@PurchasedBy", NewInvoice.PurchasedBy);
                        cmd.Parameters.AddWithValue("@InvoiceDeal", NewInvoice.InvoiceDeal);
                        cmd.Parameters.AddWithValue("@BranchID", NewInvoice.Counter.BranchID);
                        cmd.Parameters.AddWithValue("@CouterNo", NewInvoice.Counter.CouterNo);
                        cmd.ExecuteNonQuery();

                        cmd.CommandText = "INSERT INTO `InvoiceProducts`(`ID`,`Quantity`,`InvoiceId`) VALUES (@ID,@Quantity,@InvoiceId)";
                        foreach (InvoiceProduct NewInvoiceProduct in NewInvoice.Products)
                        {
                            cmd.Parameters.AddWithValue("@ID", NewInvoiceProduct.ID);
                            cmd.Parameters.AddWithValue("@Quantity", NewInvoiceProduct.Quantity);
                            cmd.Parameters.AddWithValue("@InvoiceId", NewInvoice.InvoiceId);
                            cmd.ExecuteNonQuery();
                        }

                        cmd.CommandText = "INSERT INTO `InvoicePaymentMethods`(`Method`,`Amount`,`InvoiceId`) VALUES(@Method,@Amount,@InvoiceId)";
                        foreach (InvoicePaymentMethod NewInvoicePaymentMethod in NewInvoice.Payments)
                        {
                            cmd.Parameters.AddWithValue("@Method", NewInvoicePaymentMethod.Method);
                            cmd.Parameters.AddWithValue("@Amount", NewInvoicePaymentMethod.Amount);
                            cmd.Parameters.AddWithValue("@InvoiceId", NewInvoice.InvoiceId);
                            cmd.ExecuteNonQuery();
                        }

                        Transaction.Commit();
                    }

                    DBConnection.IncrementRowCount(DatabaseTable.Invoice, Conn);
                    Debug.WriteLine($"AddNewInvoice() -> Add new row to Invoices Table");
                }

                InventryMangementSystemDbContext.IsThereUnsyncInvoices = true;
                return true;
            }
            catch (Exception ex)
            {
                Debug.WriteLine("AddNewInvoice() -> " + ex.ToString());
                return false;
            }

        }

        #endregion

        #region TableVersion

        public static void UpdateTableVersions(byte TableID, long Version)
        {
            try
            {
                using (SQLiteConnection Conn = OpenDBConnection())
                {
                    Conn.Open();

                    SQLiteCommand cmd = new SQLiteCommand();
                    cmd.Connection = Conn;
                    cmd.CommandText = "Update TableVersions Set Version = @Version Where TableID = @TableID";
                    cmd.Parameters.AddWithValue("@Version", Version);
                    cmd.Parameters.AddWithValue("@TableID", TableID);
                    cmd.ExecuteNonQuery();
                    Debug.WriteLine($"UpdateTableVersions() -> TableID = {TableID} to Version = {Version}, row updated");
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("UpdateTableVersions() -> " + ex.ToString());
            }
        }

        #endregion

        #region Product

        public static ICollection<Product> GetProducts()
        {
            ICollection<Product> Products = new List<Product>();

            try
            {
                using (SQLiteConnection Conn = OpenDBConnection())
                {
                    Conn.Open();

                    SQLiteCommand cmd = new SQLiteCommand("Select * from Products", Conn);

                    using (SQLiteDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Product Product = new Product();

                            Product.ID = reader["ID"].ToString();
                            Product.Name = reader["Name"].ToString();
                            Product.Bracode = reader["Barcode"].ToString();
                            Product.Type = (ProductType)Convert.ToByte(reader["Type"].ToString());
                            Product.Price = (float)Convert.ToDouble(reader["Price"].ToString());

                            Products.Add(Product);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("GetProducts() -> " + ex.ToString());
            }

            return Products;
        }

        public static void UpdateProducts(ICollection<Product> NewProducts)
        {
            try
            {
                using (SQLiteConnection Conn = OpenDBConnection())
                {
                    Conn.Open();

                    SQLiteCommand cmd = new SQLiteCommand();
                    cmd.Connection = Conn;

                    using (SQLiteTransaction Transaction = Conn.BeginTransaction())
                    {
                        cmd.CommandText = "Delete From Products";
                        cmd.ExecuteNonQuery();

                        cmd.CommandText = "Insert into `Products` (`ID`, `Name`, `Barcode`, `Type` , `Price`) Values(@ID, @Name, @Barcode, @Type , @Price)";

                        if (NewProducts != null)
                        {
                            foreach (Product NewProduct in NewProducts)
                            {
                                cmd.Parameters.AddWithValue("@ID", NewProduct.ID);
                                cmd.Parameters.AddWithValue("@Name", NewProduct.Name);
                                cmd.Parameters.AddWithValue("@Barcode", NewProduct.Bracode);
                                cmd.Parameters.AddWithValue("@Type", (byte)NewProduct.Type);
                                cmd.Parameters.AddWithValue("@Price", NewProduct.Price);

                                cmd.ExecuteNonQuery();
                            }
                        }

                        Transaction.Commit();
                    }

                    cmd.CommandText = "VACUUM";
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("UpdateProducts() -> " + ex.ToString());
            }
        }

        #endregion

        #region PaymentMethod

        public static ICollection<PaymentMethod> GetPaymentMethods()
        {
            ICollection<PaymentMethod> PaymentMethods = new List<PaymentMethod>();

            try
            {
                using (SQLiteConnection Conn = OpenDBConnection())
                {
                    Conn.Open();

                    SQLiteCommand cmd = new SQLiteCommand("Select * from PaymentMethods", Conn);

                    using (SQLiteDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            PaymentMethod PaymentMethod = new PaymentMethod();

                            PaymentMethod.Name = reader["Name"].ToString();
                            PaymentMethod.Note = reader["Note"].ToString();

                            PaymentMethods.Add(PaymentMethod);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("GetPaymentMethods() -> " + ex.ToString());
            }

            return PaymentMethods;
        }

        public static void UpdatePaymentMethods(ICollection<PaymentMethod> NewPaymentMethods)
        {
            try
            {
                using (SQLiteConnection Conn = OpenDBConnection())
                {
                    Conn.Open();

                    SQLiteCommand cmd = new SQLiteCommand();
                    cmd.Connection = Conn;

                    using (SQLiteTransaction Transaction = Conn.BeginTransaction())
                    {
                        cmd.CommandText = "Delete From PaymentMethods";
                        cmd.ExecuteNonQuery();

                        cmd.CommandText = "Insert into `PaymentMethods` (`Name`, `Note`) Values (@Name, @Note)";

                        if (NewPaymentMethods != null)
                        {
                            foreach (PaymentMethod NewPaymentMethod in NewPaymentMethods)
                            {

                                cmd.Parameters.AddWithValue("@Name", NewPaymentMethod.Name);
                                cmd.Parameters.AddWithValue("@Note", NewPaymentMethod.Note);

                                cmd.ExecuteNonQuery();
                            }
                        }

                        Transaction.Commit();
                    }

                    cmd.CommandText = "VACUUM";
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("UpdatePaymentMethods() -> " + ex.ToString());
            }
        }

        #endregion
    }
}
