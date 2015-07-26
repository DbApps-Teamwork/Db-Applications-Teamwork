using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenerateIncomesExensesReports.Contracts
{
    public interface IIncomesExpensesGenerator
    {
        void GenerateIncomesExpenses(IEnumerable<IncomesExpensesDto> incomesExpenses, string path);
    }
}
