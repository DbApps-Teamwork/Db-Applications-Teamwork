using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExcelSalesReports.DataAccess;
using ExcelSalesReports.DataAccess.Contracts;
using Ninject.Modules;
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

        }
    }
}
