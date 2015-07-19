using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SupermarketChainSQLServer.Data;

namespace SupermarketChainSQLServer.DataAccess.Contracts
{
    public interface ISalesRepository : IRepository<Sale>
    {
        IEnumerable<VendorSalesDto> GetSalesByVendor(DateTime startDate, DateTime endDate);

        IEnumerable<AggregatedSalesReport> GetAggregatedSalesReports(DateTime startDate, DateTime endDate);
    }
}
