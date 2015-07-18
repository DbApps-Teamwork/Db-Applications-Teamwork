using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SupermarketChainOracle.Data;

namespace SupermarketChainOracle.DataAccess
{
    public class VendorsRepository : GenericRepository<Vendor>
    {
        public VendorsRepository(DbContext context)
            :base(context)
        {     
        }
    }
}
