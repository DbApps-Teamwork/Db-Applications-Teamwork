using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using SupermarketChainSQLServer.Data;
using SupermarketChainSQLServer.DataAccess.Contracts;

namespace SupermarketChainSQLServer.DataAccess
{
    public class ProductsRepository : GenericRepository<Product>, IProductsRepository
    {
        public ProductsRepository(ISupermarketSQLServerContext context)
            :base(context)
        {
        }

        public IEnumerable<ProductDto> GetProductsWithIncomes()
        {
            var products = this.context.Products.Select(p => new ProductDto()
            {
                ProductName = p.ProductName,
                VendorId = p.VendorId,
                Incomes = p.Sales.Sum(s => s.Price * s.Quantity)
            });

            return products;
        }
    }
}
