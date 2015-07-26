using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SupermarketChainSQLite.Data;

namespace SupermarketChainSQLite.DataAccess.Contracts
{
    public interface ISupermarketChainSQLiteContext
    {
        IDbSet<ProductTax> ProductTaxes { get; set; }

        int SaveChanges();

        DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;

        IDbSet<T> Set<T>() where T : class;
    }
}
