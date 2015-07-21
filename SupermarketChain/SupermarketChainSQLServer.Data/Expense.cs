using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupermarketChainSQLServer.Data
{
    public class Expense
    {
        public int ExpenseId { get; set; }

        public DateTime ExpenseDate { get; set; }

        public decimal ExpenseSum { get; set; }

        public int VendorId { get; set; }

        public virtual Vendor Vendor { get; set; }
    }
}
