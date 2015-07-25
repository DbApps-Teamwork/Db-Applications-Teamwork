using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SupermarketChainMySQL.Data;
using SupermarketChainMySQL.Data.Contracts;
using SupermarketChainMySQL.DataAccess.Contracts;

namespace SupermarketChainMySQL.DataAccess
{
    public class SupermarketChainMySQLData : ISupermarketChainMySQLData
    {
        private ISupermarketMySQLEntities context;
        private IRepository<Product> productRepository;
        private IRepository<Vendor> vendorRepository;

        public SupermarketChainMySQLData(ISupermarketMySQLEntities context)
        {
            this.context = context;
        }

        public IRepository<Product> ProductRepository
        {
            get
            {
                if (this.productRepository == null)
                {
                    this.productRepository = new GenericRepository<Product>(this.context);
                }
                return this.productRepository;
            }
        }

        public IRepository<Vendor> VendorRepository
        {
            get
            {
                if (this.vendorRepository == null)
                {
                    this.vendorRepository = new GenericRepository<Vendor>(this.context);
                }
                return this.vendorRepository;
            }
        }

        public void Save()
        {
            this.context.SaveChanges();
        }
    }
}
