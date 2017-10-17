using System;
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

        public static SQLiteConnection OpenDBConnection()
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

                        sqliteCommand.CommandText = "CREATE TABLE `Employees` (`ID` TEXT, `Name` TEXT, PRIMARY KEY(`ID`))";
                        sqliteCommand.ExecuteNonQuery();
                        Debug.WriteLine("Employees Table Created.");

                        sqliteCommand.CommandText = "";
                        sqliteCommand.ExecuteNonQuery();
                        Debug.WriteLine("Products Table Created.");

                        sqliteCommand.CommandText = "CREATE TABLE `Products` (`ID` TEXT, `Name` TEXT, `Barcode` INTEGER, `Type` INTEGER, `Price` NUMERIC, `Time` INTEGER, PRIMARY KEY(`ID`));";
                        sqliteCommand.ExecuteNonQuery();
                        Debug.WriteLine("Invoices Table Created.");

                        sqliteCommand.CommandText = "CREATE TABLE `Customers` (`ID` INTEGER, `Name` TEXT, PRIMARY KEY(`ID`))";
                        sqliteCommand.ExecuteNonQuery();
                        Debug.WriteLine("Customers Table Created.");

                        sqliteCommand.CommandText = "CREATE TABLE `TableVersions` (`Table` INTEGER NOT NULL, `Time` INTEGER NOT NULL, PRIMARY KEY(`Table`))";
                        sqliteCommand.ExecuteNonQuery();
                        Debug.WriteLine("Verstions Table Created.");

                        #endregion

                        #region Seed Tables

                        sqliteCommand.CommandText = "insert into Versions values(@Employees, @Time); ";
                        sqliteCommand.Parameters.AddWithValue("@Employees", "Employees");
                        sqliteCommand.Parameters.AddWithValue("@Version", "0");
                        sqliteCommand.ExecuteNonQuery();

                        sqliteCommand.CommandText = "insert into Versions values(@Products, @Time); ";
                        sqliteCommand.Parameters.AddWithValue("@Products", "Products");
                        sqliteCommand.Parameters.AddWithValue("@Version", "0");
                        sqliteCommand.ExecuteNonQuery();

                        sqliteCommand.CommandText = "insert into Versions values(@Customers, @Time); ";
                        sqliteCommand.Parameters.AddWithValue("@Customers", "Customers");
                        sqliteCommand.Parameters.AddWithValue("@Customers", "0");
                        sqliteCommand.ExecuteNonQuery();

                        Debug.WriteLine("Versions Table Seeded.");

                        #endregion
                    }
                }

                _conn = new SQLiteConnection(LocalDBCSWithPW);

                return _conn;
            }
            catch
            {
                return null;
            }
        }

        public static void CloseConnection()
        {
            _conn.Close();
        }
    }
}
