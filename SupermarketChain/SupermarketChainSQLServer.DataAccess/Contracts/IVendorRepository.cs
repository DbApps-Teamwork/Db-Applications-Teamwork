using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SupermarketChainSQLServer.Data;

namespace SupermarketChainSQLServer.DataAccess.Contracts
{
    public interface IVendorRepository : IRepository<Vendor>
    {
        IEnumerable<VendorDto> GetVendorsWithExpenses();
    }
}
