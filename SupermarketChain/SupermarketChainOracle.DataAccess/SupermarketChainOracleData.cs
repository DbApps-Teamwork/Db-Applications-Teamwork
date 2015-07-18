using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SupermarketChainOracle.Data;
using SupermarketChainOracle.DataAccess.Contracts;

namespace SupermarketChainOracle.DataAccess
{
    public class SupermarketChainOracleData : ISupermarketChainOracleData
    {
        private DbContext context;
        private IRepository<Product> productRepository;
        private IRepository<Measure> measureRepository;
        private IRepository<Vendor> vendorRepository; 

        public SupermarketChainOracleData(DbContext context)
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

        public IRepository<Measure> MeasureRepository
        {
            get
            {
                if (this.measureRepository == null)
                {
                    this.measureRepository = new GenericRepository<Measure>(this.context);
                }
                return this.measureRepository;
            }
        }
    }
}
