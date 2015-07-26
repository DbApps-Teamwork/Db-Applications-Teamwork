using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SupermarketChainSQLite.Data;
using SupermarketChainSQLite.DataAccess.Contracts;

namespace SupermarketChainSQLite.DataAccess
{
    public class SupermarketChainSQLiteData : ISupermarketChainSQLiteData
    {
        private ISupermarketChainSQLiteContext context;
        private IRepository<ProductTax> productTaxRepository;

        public SupermarketChainSQLiteData(ISupermarketChainSQLiteContext context)
        {
            this.context = context;
        }

        public IRepository<ProductTax> ProductTaxRepository
        {
            get
            {
                if (this.productTaxRepository == null)
                {
                    this.productTaxRepository = new GenericRepository<ProductTax>(this.context);
                }
                return this.productTaxRepository;
            }
        }

        public void Save()
        {
            this.context.SaveChanges();
        }
    }
}
