using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SupermarketChainOracle.Data;
using SupermarketChainOracle.DataAccess;
using SupermarketChainOracle.DataAccess.Contracts;
using SupermarketChainSQLServer.DataAccess;

namespace SupermarketChain
{
    class Program
    {
        static void Main(string[] args)
        {
            // Test data access for Oracle Db
            //var data = new SupermarketChainOracleData(new SupermarketOracleEntities());
            //var products = data.ProductRepository.Get();
            //foreach (var product in products)
            //{
            //    Console.WriteLine(product.ProductName);
            //}

            // Test data access for SQL Server
            //var data = new SupermarketChainSQLServerData(new SupermarketSQLServerContext());
            //var products = data.ProductRepository.Get();
            //Console.WriteLine(products.Count());
            
        }
    }
}
