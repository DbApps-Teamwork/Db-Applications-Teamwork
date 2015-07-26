using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupermarketChainSQLite.Data
{
    public class ProductTax
    {
        public long ProductTaxId { get; set; }

        public string ProductName { get; set; }

        public decimal Tax { get; set; }   
    }
}
