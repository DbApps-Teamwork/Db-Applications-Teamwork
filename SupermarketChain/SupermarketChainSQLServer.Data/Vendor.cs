using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupermarketChainSQLServer.Data
{
    public class Vendor
    {
        public Vendor()
        {
            this.Products = new HashSet<Product>();
        }

        public int VendorId { get; set; }

        public string VendorName { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
