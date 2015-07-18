using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SupermarketChainSQLServer.Data;

namespace SupermarketChainSQLServer.DataAccess.Contracts
{
    public interface ISupermarketChainSQLServerData
    {
        IRepository<Product> ProductRepository { get; }

        IRepository<Vendor> VendorRepository { get; }

        IRepository<Measure> MeasureRepository { get; }

        IRepository<Sale> SaleRepository { get; }
    }
}
