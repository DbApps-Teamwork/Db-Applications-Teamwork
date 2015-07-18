using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcelSalesReports.DataAccess
{
    public class SaleReportDto
    {
        public SaleReportDto(string name, int quantity,
            decimal price, DateTime date, string location)
        {
            this.ProductName = name;
            this.Quantity = quantity;
            this.UnitPrice = price;
            this.SaleDate = date;
            this.Location = location;
        }

        public string ProductName { get; private set; }

        public int Quantity { get; private set; }

        public decimal UnitPrice { get; private set; }

        public DateTime SaleDate { get; private set; }

        public string Location { get; private set; }
    }
}
