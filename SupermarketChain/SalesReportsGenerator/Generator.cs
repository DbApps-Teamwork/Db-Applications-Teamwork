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
    public class Generator : ISalesReportsGenerator
    {
        private ISalesReportsLayout layout;

        public Generator(ISalesReportsLayout layout, ISalesReportsWriter writer)
        {
            this.layout = layout;
            this.Writer = writer;
        }

        public ISalesReportsWriter Writer { get; set; }

        public void GenerateSalesReports(IEnumerable<VendorSalesDto> salesReports)
        {
            var reports = this.layout.PopulateLayout(salesReports);
            this.Writer.WriteSalesReports(reports);
        }
    }
}
