namespace GenerateJsonReports
{
   
    using System;
    using System.Data.Entity;
    using System.IO;
    using System.Linq;
    using Newtonsoft.Json;

    public class JsonReportExport
    {

        //virtual machine path to project folder
        public static string reportsFolder = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\Visual Studio 2013\\Projects\\SupermarketChain\\JSON\\";
        //public static string reportsFolder = "../../../JSON"

        public void Report(DateTime startDate, DateTime endDate)
        {

            if (!Directory.Exists(reportsFolder))
            {
                Console.WriteLine("Folder created");
                Directory.CreateDirectory(reportsFolder);
            }

            var context = new SupermarketChainEntity();
            var reports = GetJsonReport(context, startDate, endDate);

            ExportToFile(reports);
           
        }

        public static IQueryable<JsonReport> GetJsonReport(SupermarketChainEntity context, DateTime startDate, DateTime endDate)
        {
            
            var reports = context.Sales
                .Include(e => e.Product)
                .Include(e => e.Product.Vendor)
                .Where(s => s.SaleDate >= startDate && s.SaleDate <= endDate)
                .Select(x => new JsonReport
                {
                    Id = x.ProductId,
                    ProductName = x.Product.ProductName,
                    VendorName = x.Product.Vendor.VendorName,
                    QtySold = x.Quantity,
                    TotalIncome = x.Quantity * x.Product.Price
                });

            if (reports.Any() == false)
            {
                throw new ArgumentNullException(string.Format("No sales in that period"));
            }

            return reports;
        }

        public static void ExportToFile(IQueryable<JsonReport> reports)
        {
            foreach (var report in reports)
            {
                string reportFilePath = string.Format("{0}{1}{2}", reportsFolder, report.Id, ".json");

                var writer = new StreamWriter(reportFilePath);

                using (writer)
                {
                    string serialized = JsonConvert.SerializeObject(report, Formatting.Indented);

                    writer.WriteLine(serialized);
                    Console.WriteLine(serialized);
                }
                
            }
          
        }


    }


}
