using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SupermarketChainOracle.Data;

namespace SupermarketChainOracle.DataAccess.Contracts
{
    public interface ISupermarketChainOracleData
    {
        IRepository<PRODUCT> ProductRepository { get; }
        
        IRepository<MEASURE> MeasureRepository { get; }

        IRepository<VENDOR> VendorRepository { get; }
    }
}
