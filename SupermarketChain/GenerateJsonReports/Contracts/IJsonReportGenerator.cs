using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SupermarketChainSQLServer.Data;

namespace GenerateJsonReports.Contracts
{
    public interface IJsonReportGenerator
    {
        void ExportToFile(IEnumerable<JsonReport> reports, string path);

        void ImportToMongo(IEnumerable<JsonReport> reports);
    }
}
