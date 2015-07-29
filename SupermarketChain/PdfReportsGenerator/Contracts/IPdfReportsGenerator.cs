using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SupermarketChainSQLServer.Data;

namespace PdfReportsGenerator.Contracts
{
    public interface IPdfReportsGenerator
    {
        void GenerateReports(IEnumerable<AggregatedSalesReport> reports, string path);
    }
}
