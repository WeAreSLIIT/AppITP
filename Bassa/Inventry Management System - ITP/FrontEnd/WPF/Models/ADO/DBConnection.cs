using Models.Core;
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
        private static string _dbFileName = "data.dat";
        private static string _password = "pass";

        private static SQLiteConnection _conn;

        private static string LocalDBCSNoPW = ConfigurationManager.ConnectionStrings["LocalDBCSNoPW"].ConnectionString;
        private static string LocalDBCSWithPW = ConfigurationManager.ConnectionStrings["LocalDBCSWithPW"].ConnectionString;

        public static bool IsThisFirstTime()
        {
            return !File.Exists(_dbFileName);
        }

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
                        Conn.ChangePassword(_password);
                        Console.WriteLine("Database Created.");
                    }

                    using (SQLiteConnection Conn = new SQLiteConnection(LocalDBCSWithPW))
                    {
                        Conn.Open();
                        SQLiteCommand sqliteCommand = new SQLiteCommand();
                        sqliteCommand.Connection = Conn;

                        #region Create Tables

                        //sqliteCommand.CommandText = "CREATE TABLE `Employees` (`ID` TEXT, `Name` TEXT, PRIMARY KEY(`ID`))";
                        //sqliteCommand.ExecuteNonQuery();
                        //Debug.WriteLine("WPF -> Employees Table Created.");

                        //sqliteCommand.CommandText = "";
                        //sqliteCommand.ExecuteNonQuery();
                        //Debug.WriteLine("WPF -> Invoices Table Created.");

                        sqliteCommand.CommandText = "CREATE TABLE `Products` (`ID` TEXT, `Name` TEXT, `Barcode` INTEGER, `Type` INTEGER, `Price` NUMERIC, PRIMARY KEY(`ID`))";
                        sqliteCommand.ExecuteNonQuery();
                        Debug.WriteLine("WPF -> Products Table Created.");

                        sqliteCommand.CommandText = "CREATE TABLE `PaymentMethods` (`Name` TEXT, `Note` TEXT, PRIMARY KEY(`Name`))";
                        sqliteCommand.ExecuteNonQuery();
                        Debug.WriteLine("WPF -> PaymentMethods Table Created.");

                        sqliteCommand.CommandText = "CREATE TABLE `TableVersions` (`TableID` INTEGER NOT NULL, `Version` INTEGER NOT NULL, PRIMARY KEY(`Table`))";
                        sqliteCommand.ExecuteNonQuery();
                        Debug.WriteLine("WPF -> Verstions Table Created.");

                        #endregion

                        #region Seed Tables

                        sqliteCommand.CommandText = "insert into TableVersions values(@Products, @Version); ";
                        sqliteCommand.Parameters.AddWithValue("@Products", "1");
                        sqliteCommand.Parameters.AddWithValue("@Version", "0");
                        sqliteCommand.ExecuteNonQuery();

                        sqliteCommand.CommandText = "insert into TableVersions values(@PaymentMethods, @Version); ";
                        sqliteCommand.Parameters.AddWithValue("@PaymentMethods", "2");
                        sqliteCommand.Parameters.AddWithValue("@Version", "0");
                        sqliteCommand.ExecuteNonQuery();

                        //sqliteCommand.CommandText = "insert into TableVersions values(@Employees, @Version); ";
                        //sqliteCommand.Parameters.AddWithValue("@Employees", "Employees");
                        //sqliteCommand.Parameters.AddWithValue("@Version", "0");
                        //sqliteCommand.ExecuteNonQuery();

                        //sqliteCommand.CommandText = "insert into TableVersions values(@Employees, @Version); ";
                        //sqliteCommand.Parameters.AddWithValue("@Employees", "Employees");
                        //sqliteCommand.Parameters.AddWithValue("@Version", "0");
                        //sqliteCommand.ExecuteNonQuery();

                        Debug.WriteLine("WPF -> Versions Table Seeded.");

                        #endregion
                    }
                }

                _conn = new SQLiteConnection(LocalDBCSWithPW);

                return _conn;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
                return null;
            }
        }

        public static ICollection<TableVersion> GetTableVersions()
        {
            ICollection<TableVersion> TableVersions = new List<TableVersion>();

            try
            {
                using (SQLiteConnection Conn = OpenDBConnection())
                {
                    Conn.Open();

                    SQLiteCommand cmd = new SQLiteCommand("Select * from TableVersions", Conn);

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
            catch { }

            return TableVersions;
        }

        public static void UpdateTableVersions(byte TableID, long Version)
        {
            try
            {
                using (SQLiteConnection Conn = OpenDBConnection())
                {
                    Conn.Open();

                    SQLiteCommand cmd = new SQLiteCommand();
                    cmd.Connection = Conn;
                    cmd.CommandText = "Update TableVersion Version = @Version Where TableID = @TableID";
                    cmd.Parameters.AddWithValue("@Version", Version);
                    cmd.Parameters.AddWithValue("@TableID", TableID);
                    cmd.ExecuteNonQuery();
                }
            }
            catch { }
        }

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
            catch { }

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

                        foreach (Product NewProduct in NewProducts)
                        {
                            cmd.Parameters.AddWithValue("@ID", NewProduct.ID);
                            cmd.Parameters.AddWithValue("@Name", NewProduct.Name);
                            cmd.Parameters.AddWithValue("@Barcode", NewProduct.Bracode);
                            cmd.Parameters.AddWithValue("@Type", (byte)NewProduct.Type);
                            cmd.Parameters.AddWithValue("@Price", NewProduct.Price);

                            cmd.ExecuteNonQuery();
                        }

                        Transaction.Commit();
                    }

                    cmd.CommandText = "VACUUM";
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString() + " P1");
            }
        }

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
            catch { }

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
                        
                        cmd.CommandText = "Insert into `PaymentMethods` (`Name`, `Note`) Values(@Name, @Note)";

                        foreach (PaymentMethod NewPaymentMethod in NewPaymentMethods)
                        {

                            cmd.Parameters.AddWithValue("@Name", NewPaymentMethod.Name);
                            cmd.Parameters.AddWithValue("@Note", NewPaymentMethod.Note);

                            cmd.ExecuteNonQuery();
                        }

                        Transaction.Commit();
                    }

                    cmd.CommandText = "VACUUM";
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString() + " P2");
            }
        }
    }
}
