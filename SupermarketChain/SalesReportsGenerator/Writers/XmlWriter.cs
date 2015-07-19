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
    public class XmlWriter : ISalesReportsWriter
    {
        public XmlWriter(string path)
        {
            this.Path = path;
        }

        public string Path { get; private set; }

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
