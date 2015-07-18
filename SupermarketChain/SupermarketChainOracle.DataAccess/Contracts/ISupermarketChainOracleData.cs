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
        IRepository<Product> ProductRepository { get; }
        
        IRepository<Measure> MeasureRepository { get; }

        IRepository<Vendor> VendorRepository { get; }
    }
}
