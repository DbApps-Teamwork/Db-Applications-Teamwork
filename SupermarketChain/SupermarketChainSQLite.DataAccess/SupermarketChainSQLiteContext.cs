using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SupermarketChainSQLite.Data;
using SupermarketChainSQLite.DataAccess.Contracts;

namespace SupermarketChainSQLite.DataAccess
{
    public class SupermarketChainSQLiteContext : DbContext, ISupermarketChainSQLiteContext
    {
        public IDbSet<ProductTax> ProductTaxes { get; set; }

        public new IDbSet<T> Set<T>() where T : class
        {
            return base.Set<T>();
        }
    }
}
