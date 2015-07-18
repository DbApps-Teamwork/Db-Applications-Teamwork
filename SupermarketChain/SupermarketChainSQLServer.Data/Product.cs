using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupermarketChainSQLServer.Data
{
    public class Product
    {
        public int ProductId { get; set; }

        [Required]
        [StringLength(100)]
        public string ProductName { get; set; }

        public decimal Price { get; set; }

        public int VendorId { get; set; }

        public virtual Vendor Vendor { get; set; }

        public int MeasureId { get; set; }

        public virtual Measure Measure { get; set; }

        public virtual ICollection<Sale> Sales { get; set; }
    }
}
