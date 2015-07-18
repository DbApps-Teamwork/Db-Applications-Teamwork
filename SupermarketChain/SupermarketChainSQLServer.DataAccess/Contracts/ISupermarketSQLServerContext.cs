using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SupermarketChainSQLServer.Data;

namespace SupermarketChainSQLServer.DataAccess.Contracts
{
    public interface ISupermarketSQLServerContext
    {
        IDbSet<Product> Products { get; set; }

        IDbSet<Vendor> Vendors { get; set; }

        IDbSet<Measure> Measures { get; set; }

        IDbSet<Sale> Sales { get; set; }

        int SaveChanges();

        DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;

        IDbSet<T> Set<T>() where T : class;
    }
}
