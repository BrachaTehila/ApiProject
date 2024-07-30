using DTO;
using Entities;
using Microsoft.EntityFrameworkCore;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class ProductService : IProductService
    {

        private IProductRepository _repository;
        public ProductService(IProductRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Product>> getAllProduct( string? desc, int? minPrice, int? maxPrice, int?[] categoriesId)
        {
            return await _repository.getAllProduct(   desc,  minPrice,  maxPrice,categoriesId);
        }
   


    }
}
