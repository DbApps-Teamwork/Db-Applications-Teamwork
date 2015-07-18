using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupermarketChainSQLServer.Data
{
    public class Measure
    {
        public Measure()
        {
            this.Products = new HashSet<Product>();
        }

        public int MeasureId { get; set; }

        [Required]
        [StringLength(50)]
        public string MeasureName { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}
