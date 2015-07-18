using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SupermarketChainSQLServer.Data;

namespace SupermarketChainSQLServer.DataAccess
{
    public class SupermarketSQLServerContext : DbContext
    {
        public DbSet<Product> Products { get; set; }

        public DbSet<Vendor> Vendors { get; set; }

        public DbSet<Measure> Measures { get; set; }

        public DbSet<Sale> Sales { get; set; }
    }
}
