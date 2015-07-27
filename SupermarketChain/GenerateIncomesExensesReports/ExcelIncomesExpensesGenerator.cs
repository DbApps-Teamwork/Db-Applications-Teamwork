using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GenerateIncomesExensesReports.Contracts;
using OfficeOpenXml;
using System.Drawing;
using OfficeOpenXml.Style;

namespace GenerateIncomesExensesReports
{
    public class ExcelIncomesExpensesGenerator : IIncomesExpensesGenerator
    {
        public void GenerateIncomesExpenses(IEnumerable<IncomesExpensesDto> incomesExpenses, string path)
        {
            FileInfo newFile = new FileInfo(path);

            using (ExcelPackage package = new ExcelPackage(newFile))
            {
                ExcelWorksheet worksheet = package.Workbook.Worksheets.Add("Reports");

                this.SetColumns(worksheet);
                this.GenerateHeader(worksheet);
                int currentRow = 2;
                foreach (var entry in incomesExpenses)
                {
                    this.GenerateRow(worksheet, entry, currentRow);
                    currentRow++;
                }

                package.Save();
            }           
        }

        private void GenerateHeader(ExcelWorksheet worksheet)
        {
            worksheet.Cells["A1"].Value = "Vendor";
            worksheet.Cells["B1"].Value = "Incomes";
            worksheet.Cells["C1"].Value = "Expenses";
            worksheet.Cells["D1"].Value = "Total Taxes";
            worksheet.Cells["E1"].Value = "Financial Result";
            worksheet.Cells["A1"].Style.Fill.PatternType = ExcelFillStyle.Solid;
            worksheet.Cells["B1"].Style.Fill.PatternType = ExcelFillStyle.Solid;
            worksheet.Cells["C1"].Style.Fill.PatternType = ExcelFillStyle.Solid;
            worksheet.Cells["D1"].Style.Fill.PatternType = ExcelFillStyle.Solid;
            worksheet.Cells["E1"].Style.Fill.PatternType = ExcelFillStyle.Solid;
            worksheet.Cells["A1"].Style.Fill.BackgroundColor.SetColor(Color.LightSkyBlue);
            worksheet.Cells["B1"].Style.Fill.BackgroundColor.SetColor(Color.LightSkyBlue);
            worksheet.Cells["C1"].Style.Fill.BackgroundColor.SetColor(Color.LightSkyBlue);
            worksheet.Cells["D1"].Style.Fill.BackgroundColor.SetColor(Color.LightSkyBlue);
            worksheet.Cells["E1"].Style.Fill.BackgroundColor.SetColor(Color.LightSkyBlue);
        }

        private void GenerateRow(ExcelWorksheet worksheet, IncomesExpensesDto entry, int rowId)
        {
            worksheet.Cells["A" + rowId].Value = entry.VendorName;
            worksheet.Cells["B" + rowId].Value = entry.Incomes;
            worksheet.Cells["C" + rowId].Value = entry.Expenses;
            worksheet.Cells["D" + rowId].Value = entry.TotalTaxes;
            worksheet.Cells["E" + rowId].Value = entry.Incomes - entry.Expenses - entry.TotalTaxes;
        }

        private void SetColumns(ExcelWorksheet worksheet)
        {
            worksheet.Column(1).Width = 20;
            worksheet.Column(2).Width = 20;
            worksheet.Column(3).Width = 20;
            worksheet.Column(4).Width = 20;
            worksheet.Column(5).Width = 20;
        }
    }
}
