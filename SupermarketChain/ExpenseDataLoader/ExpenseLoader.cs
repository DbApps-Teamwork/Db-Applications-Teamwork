using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExpenseDataLoader.Contracts;
using SupermarketChainSQLServer.Data;

namespace ExpenseDataLoader
{
    public class ExpenseLoader
    {
        private IExpensesReader reader;

        public ExpenseLoader(IExpensesReader reader)
        {
            this.reader = reader;
        }

        public IEnumerable<ExpenseDto> LoadExpenses()
        {
            var expenses = this.reader.ReadExpenses();
            return expenses;
        }
    }
}
