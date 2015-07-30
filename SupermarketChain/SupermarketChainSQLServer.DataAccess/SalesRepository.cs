using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Objects;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using SupermarketChainSQLServer.Data;
using SupermarketChainSQLServer.DataAccess.Contracts;

namespace SupermarketChainSQLServer.DataAccess
{
    public class SalesRepository : GenericRepository<Sale>, ISalesRepository
    {
        public SalesRepository(ISupermarketSQLServerContext context)
            :base(context)
        {           
        }

        public IEnumerable<VendorSalesDto> GetSalesByVendor(DateTime startDate, DateTime endDate)
        {
            IQueryable<Sale> query = this.dbSet;

            var sales = query
                .Where(s => EntityFunctions.TruncateTime(s.SaleDate) >= EntityFunctions.TruncateTime(startDate) && 
                    EntityFunctions.TruncateTime(s.SaleDate) <= EntityFunctions.TruncateTime(endDate))
               .GroupBy(s => new { s.Product.Vendor.VendorName, DatePart = EntityFunctions.TruncateTime(s.SaleDate) })
               .Select(g => new VendorSalesDto()
               {
                   VendorName = g.Key.VendorName,
                   Date = (DateTime)g.Key.DatePart,
                   Sum = g.Sum(sale => sale.Price * sale.Quantity)
               })
               .OrderBy(vs => vs.VendorName)
               .ThenBy(vs => vs.Date);

            return sales.ToList();
        }

        public IEnumerable<AggregatedSalesReport> GetAggregatedSalesReports(DateTime startDate, DateTime endDate)
        {
            IQueryable<Sale> query = this.dbSet;

            var sales = query
                .Where(s => EntityFunctions.TruncateTime(s.SaleDate) >= EntityFunctions.TruncateTime(startDate) &&
                    EntityFunctions.TruncateTime(s.SaleDate) <= EntityFunctions.TruncateTime(endDate))
               .Select(s => new AggregatedSalesReport()
               {
                   Date = s.SaleDate,
                   ProductName = s.Product.ProductName,
                   Location = s.Location,
                   Quantity = s.Quantity,
                   UnitPrice = s.Price,
                   Sum = s.Quantity * s.Price
               })
               .OrderBy(s => s.Date)
               .ThenBy(s => s.ProductName);

            return sales.ToList();
        }

        public IEnumerable<JsonReport> GetJsonReports(DateTime startDate, DateTime endDate)
        {
            var reports = context.Products
                .Where(p => p.Sales.Any(s => s.SaleDate >= startDate && s.SaleDate <= endDate))
                .Select(p => new JsonReport()
                {
                    Id = p.ProductId,
                    ProductName = p.ProductName,
                    VendorName = p.Vendor.VendorName,
                    QtySold = p.Sales
                        .Where(s => s.SaleDate >= startDate && s.SaleDate <= endDate)
                        .Sum(s => s.Quantity),
                    TotalIncome = p.Sales
                        .Where(s => s.SaleDate >= startDate && s.SaleDate <= endDate)
                        .Sum(s => (s.Quantity * s.Price))
                })
                .ToList();

            return reports;
        }
    }
}
