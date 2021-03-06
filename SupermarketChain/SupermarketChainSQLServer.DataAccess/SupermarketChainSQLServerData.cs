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
        private IProductsRepository productRepository;
        private IRepository<Measure> measureRepository;
        private IVendorRepository vendorRepository;
        private ISalesRepository saleRepository;
        private IRepository<Expense> expenseRepository;

        public SupermarketChainSQLServerData(ISupermarketSQLServerContext context)
        {
            this.context = context;
        }

        public IProductsRepository ProductRepository
        {
            get
            {
                if (this.productRepository == null)
                {
                    this.productRepository = new ProductsRepository(this.context);
                }
                return this.productRepository;
            }
        }

        public IVendorRepository VendorRepository
        {
            get
            {
                if (this.vendorRepository == null)
                {
                    this.vendorRepository = new VendorsRepository(this.context);
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

        public ISalesRepository SaleRepository
        {
            get
            {
                if (this.saleRepository == null)
                {
                    this.saleRepository = new SalesRepository(this.context);
                }
                return this.saleRepository;
            }
        }

        public IRepository<Expense> ExpenseRepository
        {
            get
            {
                if (this.expenseRepository == null)
                {
                    this.expenseRepository = new GenericRepository<Expense>(this.context);
                }
                return this.expenseRepository;
            }
        }

        public void Save()
        {
            this.context.SaveChanges();
        }
    }
}
