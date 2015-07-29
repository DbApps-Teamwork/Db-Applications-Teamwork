using System.Collections.Generic;
using GenerateJsonReports.Contracts;
using SupermarketChainSQLServer.Data;

namespace GenerateJsonReports
{  
    using System.IO;
    using Newtonsoft.Json;
    using MongoDB.Driver;

    public class JsonReportExport : IJsonReportGenerator
    {
        private const string MongoHost = "mongodb://localhost";
        private const string MongoDbName = "Sales";

        public void ExportToFile(IEnumerable<JsonReport> reports, string path)
        {
            foreach (var report in reports)
            {
                //for each products, create a file with .json ext in the Json-Reports folder
                var writer = new StreamWriter(path);
                using (writer)
                {
                    //output file will have indentation 
                    string serialized = JsonConvert.SerializeObject(report, Formatting.Indented);
                    writer.WriteLine(serialized);
                }         
            }
        }

        //create connection to MongoDB server, to provided db and host
        private MongoDatabase GetMongoDb(string dbname, string host)
        {
            var client = new MongoClient(host);
            var server = client.GetServer();
            return server.GetDatabase(dbname);
        }

        //using the above created connection, import the information to Collection SalesByProductReports
        public void ImportToMongo(IEnumerable<JsonReport> reports)
        {
            var mongodb = this.GetMongoDb(MongoDbName, MongoHost);

            var salesData = mongodb.GetCollection<JsonReport>("SalesByProductReports");
            salesData.InsertBatch(reports);
        }
    }
}
