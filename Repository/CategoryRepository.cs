using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private  StoreDataBase2Context _dbContext;
        public CategoryRepository(StoreDataBase2Context dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<IEnumerable<Category>> getAllCategories()
        {
            return await _dbContext.Categories.ToListAsync();

        }

    }
}
