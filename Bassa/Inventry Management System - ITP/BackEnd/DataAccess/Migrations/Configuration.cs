namespace DataAccess.Migrations
{
    using DataAccess.Core.Domain;
    using System.Collections.Generic;
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<DataAccess.Persistence.InventryMangementSystemDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(DataAccess.Persistence.InventryMangementSystemDbContext context)
        {
            context.TableVersions.AddRange(new List<TableVersion>()
            {
                new TableVersion()
                {
                    Table = DatabaseTable.Product,
                    Time = 1
                },
                new TableVersion()
                {
                    Table = DatabaseTable.PaymentMethod,
                    Time = 1
                }
            });

            context.Branches.Add(new Branch()
            {
                Location = "Malabe",
                Name = "Malabe",

                Counters = new List<Counter>()
                {
                    new Counter()
                    {
                        BranchCounterNo = 1
                    }
                },

                Address = "100",
                BranchLevel = 1,
                BranchTitle = "Fodd City",
                Latitude = 100,
                ContactNumbers = new string[] {"0778511690"},
                Email = "brach01@chath.com",
                Longtitude = 100
            });

            context.Employees.Add(new Employee()
            {
                FirstName = "Chathuranga",
                LastName = "Basnayake",
                InitialName = "BM",
                City = "Homagama",
                Email = "chath@outlook.com",
                Gender = Gender.Male,
                NIC = "951120570v",
                JobTitle = "Cashier",
                Town = "Colombo",
                Province = "Western",
                Street = "Wimana Rd",
                Suspend = false
            });
        }
    }
}
