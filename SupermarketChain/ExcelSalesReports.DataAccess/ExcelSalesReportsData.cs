using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Excel;
using ExcelSalesReports.DataAccess.Contracts;
using ICSharpCode.SharpZipLib.Zip;

namespace ExcelSalesReports.DataAccess
{
    public class ExcelSalesReportsData : IExcelReportsData
    {
        public IEnumerable<SaleReportDto> GetSalesReports(string archivePath)
        {
            var reports = new List<SaleReportDto>();
            var zipFile = this.CreateZipFile(archivePath);
            var archiveEntries = this.GetArchiveEntries(archivePath);

            foreach (var archiveEntry in archiveEntries)
            {
                var salesReports = this.GetSalesReportData(archiveEntry, zipFile);
                reports.AddRange(salesReports);
            }

            return reports;
        }

        private IEnumerable<SaleReportDto> GetSalesReportData(ZipEntry entry, ZipFile archive)
        {
            using (var stream = archive.GetInputStream(entry))
            {
                var memoryStream = this.CopyToMemory(stream);
                IExcelDataReader excelReader = ExcelReaderFactory.CreateBinaryReader(memoryStream);
                var date = this.GetDateFromFileName(entry.Name);
                var salesReports = this.CreateSalesReports(date, excelReader);
                return salesReports;
            }
        }

        private IEnumerable<SaleReportDto> CreateSalesReports(DateTime date, IExcelDataReader dataReader)
        {
            var reports = new List<SaleReportDto>();
            var worksheet = dataReader.AsDataSet().Tables["Sales"];
            IList<DataRow> rows = (from DataRow r in worksheet.Rows select r).ToList();
            var location = rows[1].ItemArray[1].ToString();
            var rowsCount = rows.Count();

            for (int i = 3; i < rowsCount - 1; i++)
            {
                var productName = rows[i].ItemArray[1].ToString();
                var quantity = Convert.ToInt32(rows[i].ItemArray[2]);
                var price = Convert.ToDecimal(rows[i][3]);
                var report = new SaleReportDto(productName, quantity, price, date, location);
                reports.Add(report);
            }
            return reports;
        }

        private DateTime GetDateFromFileName(string name)
        {
            var tokens = name.Split(new char[] {'.', '-'}, StringSplitOptions.RemoveEmptyEntries);
            var dateString = String.Format("{0}-{1}-{2}", tokens[tokens.Count() - 3], tokens[tokens.Count() - 4],
                tokens[tokens.Count() - 2]);

            IFormatProvider culture = new System.Globalization.CultureInfo("en-US", true);
            DateTime date = DateTime.Parse(dateString, culture, System.Globalization.DateTimeStyles.AssumeLocal);
            return date;
        }

        private ZipFile CreateZipFile(string archivePath)
        {
            var filestream = new FileStream(archivePath, FileMode.Open, FileAccess.Read);
            var zipFile = new ZipFile(filestream);
            return zipFile;
        }

        private IEnumerable<ZipEntry> GetArchiveEntries(string archivePath)
        {
            var zip = new ZipInputStream(File.OpenRead(archivePath));
            ZipEntry item;
            var entries = new List<ZipEntry>();

            while ((item = zip.GetNextEntry()) != null)
            {
                if (item.Name.EndsWith(".xls"))
                {
                    entries.Add(item);
                }
            }
            return entries;
        }

        private MemoryStream CopyToMemory(Stream input)
        {
            MemoryStream ret = new MemoryStream();

            byte[] buffer = new byte[8192];
            int bytesRead;
            while ((bytesRead = input.Read(buffer, 0, buffer.Length)) > 0)
            {
                ret.Write(buffer, 0, bytesRead);
            }

            ret.Position = 0;
            return ret;
        }
    }
}
