using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SupermarketChainSQLServer.Data;

namespace ExpenseDataLoader.Contracts
{
    public interface IExpensesReader
    {
        IEnumerable<ExpenseDto> ReadExpenses();
    }
}
