using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SupermarketChainSQLServer.Data;

namespace SalesReportsGenerator.Contracts
{
    public interface ISalesReportsGenerator
    {
        void GenerateSalesReports(IEnumerable<VendorSalesDto> salesReports);

        ISalesReportsWriter Writer { get; set; }
    }
}
