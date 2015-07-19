using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using SupermarketChainSQLServer.Data;

namespace XmlSalesReportsGenerator
{
    public class SalesReportsGenerator
    {
        public XElement GenerateSalesReports(IEnumerable<VendorSalesDto> salesReports, string path)
        {
            var salesElement = new XElement("sales");
            string lastVendorName = null;
            XElement currentSaleElement = null;

            foreach (var saleReport in salesReports)
            {
                if (!(lastVendorName != null && lastVendorName.Equals(saleReport.VendorName)))
                {
                    if (currentSaleElement != null)
                    {
                        salesElement.Add(currentSaleElement);
                    }
                    currentSaleElement = new XElement("sale");
                    currentSaleElement.SetAttributeValue("vendor", saleReport.VendorName);
                }

                currentSaleElement.Add(this.CreateSaleElement(saleReport));
                lastVendorName = saleReport.VendorName;
            }
            salesElement.Add(currentSaleElement);

            return salesElement;
        }

        private XElement CreateSaleElement(VendorSalesDto saleReport)
        {
            var element = new XElement("summary");
            element.SetAttributeValue("date", saleReport.Date);
            element.SetAttributeValue("total-sum", saleReport.Sum);

            return element;
        }
    }
}
