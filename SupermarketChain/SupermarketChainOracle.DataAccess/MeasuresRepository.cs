using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SupermarketChainOracle.Data;

namespace SupermarketChainOracle.DataAccess
{
    public class MeasuresRepository : GenericRepository<MEASURE>
    {
        public MeasuresRepository(DbContext context)
            :base(context)
        {     
        }
    }
}
