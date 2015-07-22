using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using SalesReportsGenerator.Contracts;

namespace SalesReportsGenerator.Writers
{
    public class XmlSalesReportsWriter : ISalesReportsWriter
    {
        public XmlSalesReportsWriter(string path = "")
        {
            this.Path = path;
        }

        public string Path { get; set; }

        public void WriteSalesReports(string reports)
        {
            using (var writer = new XmlTextWriter(this.Path, null))
            {
                writer.WriteStartDocument();
                writer.WriteRaw(Environment.NewLine + reports);
            }
        }
    }
}
