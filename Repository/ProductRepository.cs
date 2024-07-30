using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{

    public class ProductRepository : IProductRepository
    {
        private StoreDataBase2Context _dbContext;
        public ProductRepository(StoreDataBase2Context dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Product>> getAllProduct(string? desc, int? minPrice, int? maxPrice, int?[] categoriesId)
        {
            var query = _dbContext.Products.Where(product =>
            (desc == null ? (true) : (product.Description.Contains(desc)))
            && (minPrice == null ? (true) : (product.Price >= minPrice))
            && (maxPrice == null ? (true) : (product.Price <= maxPrice))
            && (categoriesId.Length == 0 ? (true) : (categoriesId.Contains(product.CategoryId)))).OrderBy(p => p.Price).Include(i => i.Category);
            Console.WriteLine(query.ToQueryString());
            IEnumerable<Product> products = await query.ToListAsync();
            return products;
        }

        public async Task<IEnumerable<int>> getPricesById(int[] ids)
        {
            IEnumerable<Product> products = _dbContext.Products.Where(p => ids.Contains(p.ProductId));
            int[] prices = new int[products.Count()];
            for (int i = 0; i < products.Count(); i++)
            {
                prices[i] = (int)products.ElementAt(i).Price;

            }
            return prices;
        }
    }
}
