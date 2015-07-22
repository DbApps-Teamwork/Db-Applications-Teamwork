using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExpenseDataLoader.Contracts;
using SupermarketChainSQLServer.Data;

namespace ExpenseDataLoader
{
    public class ExpenseLoader : IExpenseLoader
    {
        public ExpenseLoader(IExpensesReader reader)
        {
            this.Reader = reader;
        }

        public IExpensesReader Reader { get; set; }

        public IEnumerable<ExpenseDto> LoadExpenses()
        {
            var expenses = this.Reader.ReadExpenses();
            return expenses;
        }
    }
}
