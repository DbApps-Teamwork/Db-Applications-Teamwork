namespace GenerateJsonReports
{
   
    using System;
    using System.Data.Entity;
    using System.IO;
    using System.Linq;
    using Newtonsoft.Json;
    using MongoDB.Driver;

    //TODO: PR: make project take outer data

    public class JsonReportExport
    {

        //virtual machine path to project folder
        public static string reportsFolder = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\Visual Studio 2013\\Projects\\Db-Applications-Teamwork\\SupermarketChain\\JSON-Reports\\";
        
        //On native windows machine
        //public static string reportsFolder = "../../../JSON-Reports";

        public static string MongoHost = "mongodb://localhost";
        public static string MongoDbName = "Sales";

        

        //Generate report for all sales betweet input dates
        public void Report(DateTime startDate, DateTime endDate)
        {

            //create folder on 1st time run
            if (!Directory.Exists(reportsFolder))
            {
                Console.WriteLine("Folder created");
                Directory.CreateDirectory(reportsFolder);
            }

            var context = new SupermarketChainEntity();
            var reports = GetJsonReport(context, startDate, endDate);

            ExportToFile(reports);
            ImportToMongo(reports);
           
        }

        public static IQueryable<JsonReport> GetJsonReport(SupermarketChainEntity context, DateTime startDate, DateTime endDate)
        {
            
            //get all the products sold between input dates and represent them as JsonReport
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
                //for each products, create a file with .json ext in the Json-Reports folder
                string reportFilePath = string.Format("{0}{1}{2}", reportsFolder, report.Id, ".json");

                var writer = new StreamWriter(reportFilePath);

                using (writer)
                {
                    //output file will have indentation 
                    string serialized = JsonConvert.SerializeObject(report, Formatting.Indented);

                    writer.WriteLine(serialized);
                }
                
            }
          
        }


        //create connection to MongoDB server, to provided db and host
        public static MongoDatabase GetMongoDb(string dbname, string host)
        {
            var client = new MongoClient(host);
            var server = client.GetServer();
            return server.GetDatabase(dbname);
        }


        //using the above created connection, import the information to Collection SalesByProductReports
        private static void ImportToMongo(IQueryable<JsonReport> reports)
        {
            var mongodb = GetMongoDb(MongoDbName, MongoHost);

            var salesData = mongodb.GetCollection<JsonReport>("SalesByProductReports");

            salesData.InsertBatch(reports);
            Console.WriteLine("Data imported to MongoDB");
        }
      


    }


}
