﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using ExcelSalesReports.DataAccess;
using ExcelSalesReports.DataAccess.Contracts;
using ExpenseDataLoader;
using ExpenseDataLoader.Contracts;
using ExpenseDataLoader.Readers;
using Ninject.Modules;
using SalesReportsGenerator;
using SalesReportsGenerator.Contracts;
using SalesReportsGenerator.Layouts;
using SalesReportsGenerator.Writers;
using SupermarketChainOracle.Data;
using SupermarketChainOracle.Data.Contracts;
using SupermarketChainOracle.DataAccess;
using SupermarketChainOracle.DataAccess.Contracts;
using SupermarketChainSQLServer.DataAccess;
using SupermarketChainSQLServer.DataAccess.Contracts;

namespace SupermarketChainApp.NinjectModules
{
    public class DataModule : NinjectModule
    {
        public override void Load()
        {
            Bind<ISupermarketChainSQLServerData>().To<SupermarketChainSQLServerData>().InSingletonScope();
            Bind<ISupermarketSQLServerContext>().To<SupermarketSQLServerContext>().InSingletonScope();
            
            Bind<ISupermarketChainOracleData>().To<SupermarketChainOracleData>().InSingletonScope();
            Bind<ISupermarketOracleEntities>().To<SupermarketOracleEntities>().InSingletonScope();

            Bind<IExcelReportsData>().To<ExcelSalesReportsData>();

            Bind<IExpenseLoader>().To<ExpenseLoader>();
            Bind<IExpensesReader>().To<XmlExpenseReader>();

            Bind<ISalesReportsLayout>().To<XmlLayout>();
            Bind<ISalesReportsWriter>().To<XmlSalesReportsWriter>();
            Bind<ISalesReportsGenerator>().To<Generator>();
        }
    }
}