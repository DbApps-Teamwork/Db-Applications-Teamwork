using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesReportsGenerator.Contracts
{
    public interface ISalesReportsWriter
    {
        void WriteSalesReports(string reports);

        string Path { get; set; }
    }
}
