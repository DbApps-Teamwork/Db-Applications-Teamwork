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
        private const string DefaultDateFormat = "d-MMM-yyyy";
        private iTextSharp.text.Font dataFont = 
            new iTextSharp.text.Font(iTextSharp.text.Font.NORMAL, 8f, iTextSharp.text.Font.NORMAL, new BaseColor(0, 0, 0));
        private iTextSharp.text.Font dataHeaderFont =
            new iTextSharp.text.Font(iTextSharp.text.Font.NORMAL, 8f, iTextSharp.text.Font.BOLD, new BaseColor(0, 0, 0));
        private BaseColor DateHeaderColor = new BaseColor(229, 229, 229);
        private BaseColor DataHeaderColor = new BaseColor(153, 153, 153);
        private BaseColor TableFooterColor = new BaseColor(204, 255, 255);

        public void GenerateReports(IEnumerable<AggregatedSalesReport> reports, string path)
        {
            Document doc = new Document(PageSize.A4, 10, 10, 42, 35);
            PdfWriter.GetInstance(doc, new FileStream(path, FileMode.Create));
            doc.Open();

            PdfPTable table = new PdfPTable(5);
            int[] columnWidths = new[] {25, 11, 13, 42, 9};
            table.SetWidths(columnWidths);

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
            PdfPCell name = new PdfPCell(new Phrase(report.ProductName, dataFont));
            PdfPCell quantity = new PdfPCell(new Phrase(report.Quantity.ToString(), dataFont));
            quantity.HorizontalAlignment = 1;
            PdfPCell unitPrice = new PdfPCell(new Phrase(report.UnitPrice.ToString(), dataFont));
            unitPrice.HorizontalAlignment = 1;
            PdfPCell location = new PdfPCell(new Phrase(report.Location, dataFont));
            PdfPCell sum = new PdfPCell(new Phrase(report.Sum.ToString(), dataFont));
            sum.HorizontalAlignment = 2;
            table.AddCell(name);
            table.AddCell(quantity);
            table.AddCell(unitPrice);
            table.AddCell(location);
            table.AddCell(sum);
        }

        private void AddTableHeader(PdfPTable table)
        {
            PdfPCell header = new PdfPCell(new Phrase("Aggregated Sales Report"));
            header.HorizontalAlignment = 1;
            header.Colspan = 5;
            table.AddCell(header);
        }

        private void AddDataHeader(PdfPTable table, DateTime date)
        {
            PdfPCell dateHeader = 
                new PdfPCell(new Phrase(String.Format("Date: {0}", date.ToString(DefaultDateFormat)), dataHeaderFont));
            dateHeader.Colspan = 5;
            dateHeader.BackgroundColor = DateHeaderColor;
            table.AddCell(dateHeader);

            PdfPCell product = new PdfPCell(new Phrase("Product", dataHeaderFont));
            product.BackgroundColor = DataHeaderColor;
            PdfPCell quantity = new PdfPCell(new Phrase("Quantity", dataHeaderFont));
            quantity.BackgroundColor = DataHeaderColor;
            PdfPCell unitPrice = new PdfPCell(new Phrase("Unit Price", dataHeaderFont));
            unitPrice.BackgroundColor = DataHeaderColor;
            PdfPCell location = new PdfPCell(new Phrase("Location", dataHeaderFont));
            location.BackgroundColor = DataHeaderColor;
            PdfPCell sum = new PdfPCell(new Phrase("Sum", dataHeaderFont));
            sum.BackgroundColor = DataHeaderColor;
            table.AddCell(product);
            table.AddCell(quantity);
            table.AddCell(unitPrice);
            table.AddCell(location);
            table.AddCell(sum);
        }

        private void AddDataFooter(PdfPTable table, decimal sum, DateTime date)
        {
            PdfPCell dateFooter = 
                new PdfPCell(new Phrase(String.Format("Total sum for {0}:", date.ToString(DefaultDateFormat)), dataFont));
            dateFooter.Colspan = 4;
            dateFooter.HorizontalAlignment = 2;
            table.AddCell(dateFooter);
            PdfPCell sumFooter = new PdfPCell(new Phrase(sum.ToString(), dataHeaderFont));
            sumFooter.HorizontalAlignment = 2;
            table.AddCell(sumFooter);
        }

        private void AddTableFooter(PdfPTable table, decimal sum)
        {
            PdfPCell totalFooter = new PdfPCell(new Phrase("Grand total:", dataFont));
            totalFooter.Colspan = 4;
            totalFooter.HorizontalAlignment = 2;
            totalFooter.BackgroundColor = TableFooterColor;
            table.AddCell(totalFooter);
            PdfPCell sumFooter = new PdfPCell(new Phrase(sum.ToString(), dataHeaderFont));
            sumFooter.HorizontalAlignment = 2;
            sumFooter.BackgroundColor = TableFooterColor;
            table.AddCell(sumFooter);
        }
    }
}
