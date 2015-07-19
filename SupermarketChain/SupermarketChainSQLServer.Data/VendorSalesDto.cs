using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupermarketChainSQLServer.Data
{
    public class VendorSalesDto
    {
        public string VendorName { get; set; }

        public DateTime Date { get; set; }

        public decimal Sum { get; set; }
    }
}
