using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SupermarketChainSQLServer.Data;
using System.Drawing;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;
using PdfReportsGenerator.Contracts;

namespace PdfReportsGenerator
{
    public class PdfReportsGenerator : IPdfReportsGenerator
    {
        private const string DefaultDateFormat = "";

        public void GenerateReports(IEnumerable<AggregatedSalesReport> reports, string path)
        {
            Document doc = new Document(PageSize.A4, 10, 10, 42, 35);
            PdfWriter.GetInstance(doc, new FileStream(path, FileMode.Create));
            doc.Open();

            PdfPTable table = new PdfPTable(5);

            DateTime? currentDate = null;
            decimal currentSum = 0;
            IList<decimal> dateSums = new List<decimal>();

            this.AddTableHeader(table);
            foreach (var report in reports)
            {
                if (currentDate == null || !report.Date.Date.Equals(currentDate.Value.Date))
                {
                    if (currentDate != null)
                    {
                        this.AddDataFooter(table, currentSum, currentDate.Value);
                        dateSums.Add(currentSum);
                        currentSum = 0;
                    }
                    this.AddDataHeader(table, report.Date);
                }
                this.AddDataRow(table, report);
                currentDate = report.Date;
                currentSum += report.Sum;
            }

            if (reports.Any())
            {
                this.AddDataFooter(table, currentSum, currentDate.Value);
                dateSums.Add(currentSum);
            }
            
            this.AddTableFooter(table, dateSums.Sum());
            doc.Add(table);
            doc.Close();
        }

        private void AddDataRow(PdfPTable table, AggregatedSalesReport report)
        {
            PdfPCell name = new PdfPCell(new Phrase(report.ProductName));
            PdfPCell quantity = new PdfPCell(new Phrase(report.Quantity.ToString()));
            PdfPCell unitPrice = new PdfPCell(new Phrase(report.UnitPrice.ToString()));
            PdfPCell location = new PdfPCell(new Phrase(report.Location));
            PdfPCell sum = new PdfPCell(new Phrase(report.Sum.ToString()));
            table.AddCell(name);
            table.AddCell(quantity);
            table.AddCell(unitPrice);
            table.AddCell(location);
            table.AddCell(sum);
        }

        private void AddTableHeader(PdfPTable table)
        {
            PdfPCell header = new PdfPCell(new Phrase("Aggregated Sales Report"));
            header.Colspan = 5;
            table.AddCell(header);
        }

        private void AddDataHeader(PdfPTable table, DateTime date)
        {
            PdfPCell dateHeader = new PdfPCell(new Phrase(String.Format("Date: {0}", date)));
            dateHeader.Colspan = 5;
            table.AddCell(dateHeader);

            PdfPCell product = new PdfPCell(new Phrase("Product"));
            PdfPCell quantity = new PdfPCell(new Phrase("Quantity"));
            PdfPCell unitPrice = new PdfPCell(new Phrase("Unit Price"));
            PdfPCell location = new PdfPCell(new Phrase("Location"));
            PdfPCell sum = new PdfPCell(new Phrase("Sum"));
            table.AddCell(product);
            table.AddCell(quantity);
            table.AddCell(unitPrice);
            table.AddCell(location);
            table.AddCell(sum);
        }

        private void AddDataFooter(PdfPTable table, decimal sum, DateTime date)
        {
            PdfPCell dateFooter = new PdfPCell(new Phrase(String.Format("Total sum for {0}:", date)));
            dateFooter.Colspan = 4;
            table.AddCell(dateFooter);
            PdfPCell sumFooter = new PdfPCell(new Phrase(sum.ToString()));
            table.AddCell(sumFooter);
        }

        private void AddTableFooter(PdfPTable table, decimal sum)
        {
            PdfPCell totalFooter = new PdfPCell(new Phrase("Grand total:"));
            totalFooter.Colspan = 4;
            table.AddCell(totalFooter);
            PdfPCell sumFooter = new PdfPCell(new Phrase(sum.ToString()));
            table.AddCell(sumFooter);
        }
    }
}
