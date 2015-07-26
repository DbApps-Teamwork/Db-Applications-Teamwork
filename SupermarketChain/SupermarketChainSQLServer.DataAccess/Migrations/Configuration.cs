using SupermarketChainSQLServer.Data;

namespace SupermarketChainSQLServer.DataAccess.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<SupermarketChainSQLServer.DataAccess.SupermarketSQLServerContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(SupermarketChainSQLServer.DataAccess.SupermarketSQLServerContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
            if (!context.Sales.Any())
            {
                context.Sales.AddOrUpdate(new Sale()
                {
                    Quantity = 5,
                    Price = 2,
                    Location = "Aaaa",
                    SaleDate = DateTime.Now,
                    Product = new Product()
                    {
                        Measure = new Measure() {MeasureName = "kg"},
                        Price = 1.9m,
                        ProductName = "Fafli",
                        Vendor = new Vendor() {VendorName = "Nestle"}
                    }
                });

                context.Sales.AddOrUpdate(new Sale()
                {
                    Quantity = 10,
                    Price = 3,
                    Location = "Bbb",
                    SaleDate = DateTime.Now.AddDays(1),
                    Product = new Product()
                    {
                        Measure = new Measure() {MeasureName = "lt"},
                        Price = 2.9m,
                        ProductName = "Rakia",
                        Vendor = new Vendor() {VendorName = "Bai Ivan"}
                    }
                });
            }
        }
    }
}
