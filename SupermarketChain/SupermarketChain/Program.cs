using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExcelSalesReports.DataAccess;
using ExpenseDataLoader;
using ExpenseDataLoader.Readers;
using SalesReportsGenerator;
using SalesReportsGenerator.Layouts;
using SalesReportsGenerator.Writers;
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


            // Test getting Excel reports from zip
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


            // Test getting vendor sales reports for task #4
            //var sqlData = new SupermarketChainSQLServerData(new SupermarketSQLServerContext());
            //var salesByVendor = sqlData.SaleRepository.GetSalesByVendor(DateTime.Now, DateTime.Now.AddDays(1));
            //var xmlGenerator = new Generator(new XmlLayout(),
            //    new XmlWriter(@"C:\Users\ASUS\Desktop\Database-Apps\test.xml")); // Will be taken from the UI
            //xmlGenerator.GenerateSalesReports(salesByVendor);


            // Test getting aggregated sales report for task #3
            //var sqlData = new SupermarketChainSQLServerData(new SupermarketSQLServerContext());
            //var sales = sqlData.SaleRepository.GetAggregatedSalesReports(DateTime.Now, DateTime.Now.AddDays(2));


            // Test reading Xml expenses  task #6
            //var sqlData = new SupermarketChainSQLServerData(new SupermarketSQLServerContext());
            //var path = @"C:\Users\ASUS\Desktop\Database-Apps\Sample-Vendor-Expenses.xml"; // Will be taken from the UI
            //var expenseLoader = new ExpenseLoader(new XmlExpenseReader(path));
            //var expensesReports = expenseLoader.LoadExpenses();
            //var expenses = expensesReports.Select(e => new Expense()
            //{
            //    VendorId = sqlData.VendorRepository
            //        .Get(exp => exp.VendorName.Equals(e.VendorName)).FirstOrDefault().VendorId,
            //    ExpenseDate = e.ExpenseDate,
            //    ExpenseSum = e.ExpenseSum
            //});

        }
    }
}
