using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupermarketChainSQLServer.Data
{
    public class ExpenseDto
    {
        public string VendorName { get; set; }

        public DateTime ExpenseDate { get; set; }

        public decimal ExpenseSum { get; set; }
    }
}
