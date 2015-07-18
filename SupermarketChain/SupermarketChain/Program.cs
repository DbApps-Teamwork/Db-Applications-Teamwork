using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExcelSalesReports.DataAccess;
using SupermarketChainOracle.Data;
using SupermarketChainOracle.DataAccess;
using SupermarketChainOracle.DataAccess.Contracts;
using SupermarketChainSQLServer.Data;
using SupermarketChainSQLServer.DataAccess;

namespace SupermarketChain
{
    class Program
    {
        static void Main(string[] args)
        {
            // Test data access for Oracle Db
            //var data = new SupermarketChainOracleData(new SupermarketOracleEntities());
            //var products = data.ProductRepository.Get();
            //foreach (var product in products)
            //{
            //    Console.WriteLine(product.ProductName);
            //}


            // Test data access for SQL Server
            //var sqlData = new SupermarketChainSQLServerData(new SupermarketSQLServerContext());
            //var products = data.ProductRepository.Get();
            //Console.WriteLine(products.Count());


            // Test getting Excel reports form zip
            // After the reports are loaded they need to be mapped from SaleReportsDto to Sale entity
            //var sqlData = new SupermarketChainSQLServerData(new SupermarketSQLServerContext());
            //var excelData = new ExcelSalesReportsData();
            //var path = @"C:\Users\ASUS\Desktop\Database-Apps\Sample-Sales-Reports.zip"; // Will be taken from the UI
            //var saleReports = excelData.GetSalesReports(path);
            //var sales = saleReports.Select(s => new Sale(
            //    productId: sqlData.ProductRepository
            //        .Get(p => p.ProductName.Equals(s.ProductName)).FirstOrDefault().ProductId,
            //    quantity: s.Quantity,
            //    price: s.UnitPrice,
            //    location: s.Location,
            //    date: s.SaleDate
            //    ));
            
            //Console.ReadKey();
        }
    }
}
