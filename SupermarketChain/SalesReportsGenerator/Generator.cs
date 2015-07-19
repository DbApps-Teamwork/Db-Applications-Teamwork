using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using SalesReportsGenerator.Contracts;
using SupermarketChainSQLServer.Data;

namespace SalesReportsGenerator
{
    public class Generator
    {
        private ISalesReportsLayout layout;
        private ISalesReportsWriter writer;

        public Generator(ISalesReportsLayout layout, ISalesReportsWriter writer)
        {
            this.layout = layout;
            this.writer = writer;
        }

        public void GenerateSalesReports(IEnumerable<VendorSalesDto> salesReports)
        {
            var reports = this.layout.PopulateLayout(salesReports);
            this.writer.WriteSalesReports(reports);
        }
    }
}
