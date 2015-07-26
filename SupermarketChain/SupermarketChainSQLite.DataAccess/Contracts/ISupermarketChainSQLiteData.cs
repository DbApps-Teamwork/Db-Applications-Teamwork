using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SupermarketChainSQLite.Data;

namespace SupermarketChainSQLite.DataAccess.Contracts
{
    public interface ISupermarketChainSQLiteData
    {
        IRepository<ProductTax> ProductTaxRepository { get; }

        void Save();
    }
}
