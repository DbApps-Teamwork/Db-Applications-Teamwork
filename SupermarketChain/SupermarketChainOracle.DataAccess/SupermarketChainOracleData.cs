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
        private IRepository<PRODUCT> productRepository;
        private IRepository<MEASURE> measureRepository;
        private IRepository<VENDOR> vendorRepository; 

        public SupermarketChainOracleData(DbContext context)
        {
            this.context = context;
        }

        public IRepository<PRODUCT> ProductRepository
        {
            get
            {
                if (this.productRepository == null)
                {
                    this.productRepository = new GenericRepository<PRODUCT>(this.context);
                }
                return this.productRepository;
            }
        }

        public IRepository<VENDOR> VendorRepository
        {
            get
            {
                if (this.vendorRepository == null)
                {
                    this.vendorRepository = new GenericRepository<VENDOR>(this.context);
                }
                return this.vendorRepository;
            }
        }

        public IRepository<MEASURE> MeasureRepository
        {
            get
            {
                if (this.measureRepository == null)
                {
                    this.measureRepository = new GenericRepository<MEASURE>(this.context);
                }
                return this.measureRepository;
            }
        }
    }
}
