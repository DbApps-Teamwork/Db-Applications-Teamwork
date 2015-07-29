using SupermarketChainSQLServer.Data;

namespace SupermarketChainSQLServer.DataAccess.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<SupermarketSQLServerContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(SupermarketSQLServerContext context)
        {
            var measureLiters = new Measure()
            {
                MeasureName = "liters"
            };
            var measurePieces = new Measure()
            {
                MeasureName = "pieces"
            };

            var vendorNestle = new Vendor()
            {
                VendorName = "Nestle Sofia Corp."
            };         
            var vendorZagorka = new Vendor()
            {
                VendorName = "Zagorka Corp."
            };
            var vendorBottling = new Vendor()
            {
                VendorName = "Targovishte Bottling Company Ltd."
            };

            context.Products.Add(new Product
            {
                ProductName = "Vodka “Targovishte”",
                Vendor = vendorBottling,
                Measure = measureLiters,
                Price = 7.56m
            });

            context.Products.Add(new Product
            {
                ProductName = "Beer “Zagorka”",
                Vendor = vendorZagorka,
                Measure = measureLiters,
                Price = 0.86m
            });

            context.Products.Add(new Product
            {
                ProductName = "Beer “Beck’s”",
                Vendor = vendorZagorka,
                Measure = measureLiters,
                Price = 1.03m
            });

            context.Products.Add(new Product
            {
                ProductName = "Chocolate “Milka”",
                Vendor = vendorNestle,
                Measure = measurePieces,
                Price = 0.86m
            });

            context.SaveChanges();
        }
    }
}
