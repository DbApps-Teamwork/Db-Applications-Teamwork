using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SupermarketChainMySQL.Data;

namespace SupermarketChainMySQL.DataAccess.Contracts
{
    public interface ISupermarketChainMySQLData
    {
        IRepository<Product> ProductRepository { get; }

        IRepository<Vendor> VendorRepository { get; }

        void Save();
    }
}
