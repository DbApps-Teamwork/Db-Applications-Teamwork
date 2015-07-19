using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using SupermarketChainSQLServer.Data;

namespace SalesReportsGenerator.Contracts
{
    public interface ISalesReportsLayout
    {
        string PopulateLayout(IEnumerable<VendorSalesDto> salesReports);
    }
}
