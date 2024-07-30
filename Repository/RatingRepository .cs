using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class RatingRepository : IRatingRepository
    {

        private readonly StoreDataBase2Context _dbContext;

        public RatingRepository(StoreDataBase2Context dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task addRating(Rating rating)
        {
            await _dbContext.Ratings.AddAsync(rating);
            await _dbContext.SaveChangesAsync();
        }
    }
}
