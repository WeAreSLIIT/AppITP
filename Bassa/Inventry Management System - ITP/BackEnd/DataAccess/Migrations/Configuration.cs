namespace DataAccess.Migrations
{
    using DataAccess.Core.Domain;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<DataAccess.Persistence.InventryMangementSystemDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(DataAccess.Persistence.InventryMangementSystemDbContext context)
        {
            //Seeder Methods
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

            //Temporary Seeders
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
                }
            });
        }
    }
}
