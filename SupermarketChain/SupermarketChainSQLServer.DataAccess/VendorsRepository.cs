using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SupermarketChainSQLServer.DataAccess.Contracts;
using SupermarketChainSQLServer.Data;

namespace SupermarketChainSQLServer.DataAccess
{
    public class VendorsRepository : GenericRepository<Vendor>, IVendorRepository
    {
        public VendorsRepository(ISupermarketSQLServerContext context)
            :base(context)
        {
        }

        public IEnumerable<VendorDto> GetVendorsWithExpenses()
        {
            var vendors = this.context.Vendors.Select(v => new VendorDto()
            {
                VendorName = v.VendorName,
                Expenses = v.Expenses.Sum(s => s.ExpenseSum)
            }).ToList();

            return vendors;
        }
    }
}
