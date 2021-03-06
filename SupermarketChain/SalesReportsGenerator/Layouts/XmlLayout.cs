﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using SalesReportsGenerator.Contracts;
using SupermarketChainSQLServer.Data;

namespace SalesReportsGenerator.Layouts
{
    public class XmlLayout : ISalesReportsLayout
    {
        private const string DefaultDateFormat = "d-MMM-yyyy";
        private string dateFormat;

        public XmlLayout(string dateFormat = DefaultDateFormat)
        {
            this.dateFormat = dateFormat;
        }

        public string PopulateLayout(IEnumerable<VendorSalesDto> salesReports)
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

            return salesElement.ToString();
        }

        private XElement CreateSaleElement(VendorSalesDto saleReport)
        {
            var element = new XElement("summary");
            element.SetAttributeValue("date", saleReport.Date.ToString(this.dateFormat));
            element.SetAttributeValue("total-sum", saleReport.Sum);

            return element;
        }
    }
}
