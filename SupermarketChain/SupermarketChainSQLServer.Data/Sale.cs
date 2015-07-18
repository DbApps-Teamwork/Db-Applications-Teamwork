using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupermarketChainSQLServer.Data
{
    public class Sale
    {
        public Sale()
        {
        }

        public Sale(int productId, int quantity,
            decimal price, string location, DateTime date)
        {
            this.ProductId = productId;
            this.Quantity = quantity;
            this.Price = price;
            this.Location = location;
            this.SaleDate = date;
        }

        public int SaleId { get; set; }

        public int ProductId { get; set; }

        public virtual Product Product { get; set; }

        public int Quantity { get; set; }

        public decimal Price { get; set; }

        [Required]
        [StringLength(100)]
        public string Location { get; set; }

        public DateTime SaleDate { get; set; }
    }
}
