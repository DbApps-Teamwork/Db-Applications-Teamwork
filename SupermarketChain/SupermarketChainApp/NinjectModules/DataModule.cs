﻿using ExcelSalesReports.DataAccess;
using ExcelSalesReports.DataAccess.Contracts;
using ExpenseDataLoader;
using ExpenseDataLoader.Contracts;
using ExpenseDataLoader.Readers;
using GenerateIncomesExensesReports;
using GenerateIncomesExensesReports.Contracts;
using GenerateJsonReports;
using GenerateJsonReports.Contracts;
using Ninject.Modules;
using PdfReportsGenerator.Contracts;
using SalesReportsGenerator;
using SalesReportsGenerator.Contracts;
using SalesReportsGenerator.Layouts;
using SalesReportsGenerator.Writers;
using SupermarketChainMySQL.Data;
using SupermarketChainMySQL.Data.Contracts;
using SupermarketChainMySQL.DataAccess;
using SupermarketChainMySQL.DataAccess.Contracts;
using SupermarketChainOracle.Data;
using SupermarketChainOracle.Data.Contracts;
using SupermarketChainOracle.DataAccess;
using SupermarketChainOracle.DataAccess.Contracts;
using SupermarketChainSQLite.DataAccess;
using SupermarketChainSQLite.DataAccess.Contracts;
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

            Bind<ISupermarketMySQLEntities>().To<SupermarketChainEntitiesMySQL>();
            Bind<ISupermarketChainMySQLData>().To<SupermarketChainMySQLData>();

            Bind<ISupermarketChainSQLiteContext>().To<SupermarketChainSQLiteContext>();
            Bind<ISupermarketChainSQLiteData>().To<SupermarketChainSQLiteData>();

            Bind<IIncomesExpensesGenerator>().To<ExcelIncomesExpensesGenerator>();

            Bind<IJsonReportGenerator>().To<JsonReportExport>();

            Bind<IPdfReportsGenerator>().To<PdfReportsGenerator.PdfReportsGenerator>();
        }
    }
}
