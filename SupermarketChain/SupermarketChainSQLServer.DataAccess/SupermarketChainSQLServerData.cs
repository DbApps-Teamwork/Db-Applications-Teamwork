﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SupermarketChainSQLServer.Data;
using SupermarketChainSQLServer.DataAccess.Contracts;

namespace SupermarketChainSQLServer.DataAccess
{
    public class SupermarketChainSQLServerData : ISupermarketChainSQLServerData
    {
        private ISupermarketSQLServerContext context;
        private IRepository<Product> productRepository;
        private IRepository<Measure> measureRepository;
        private IRepository<Vendor> vendorRepository;
        private IRepository<Sale> saleRepository;

        public SupermarketChainSQLServerData(ISupermarketSQLServerContext context)
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

        public IRepository<Sale> SaleRepository
        {
            get
            {
                if (this.saleRepository == null)
                {
                    this.saleRepository = new GenericRepository<Sale>(this.context);
                }
                return this.saleRepository;
            }
        }
    }
}