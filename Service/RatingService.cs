using Entities;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class RatingService : IRatingService
    {

        public readonly IRatingRepository _repository;

        public RatingService(IRatingRepository repository)
        {
            _repository = repository;
        }

        public async Task addRating(Rating rating)
        {
            await _repository.addRating(rating);
        }
    }
}
