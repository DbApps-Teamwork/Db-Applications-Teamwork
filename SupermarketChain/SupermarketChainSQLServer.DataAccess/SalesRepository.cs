using System;
using System.Collections.Generic;
using System.Data.Objects;
using System.Linq;
using System.Net.Sockets;
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

            var sales = query.Where(s => EntityFunctions.TruncateTime(s.SaleDate) >= EntityFunctions.TruncateTime(startDate) && EntityFunctions.TruncateTime(s.SaleDate) <= EntityFunctions.TruncateTime(endDate))
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
    }
}
