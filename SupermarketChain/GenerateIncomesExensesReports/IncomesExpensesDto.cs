using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenerateIncomesExensesReports
{
    public class IncomesExpensesDto
    {
        public string VendorName { get; set; }

        public decimal Expenses { get; set; }

        public decimal Incomes { get; set; }

        public decimal TotalTaxes { get; set; }
    }
}
