using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class OrderRepository : IOrderRepository
    {

        private StoreDataBase2Context _dbContext;

        public OrderRepository(StoreDataBase2Context dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<OrdersTbl> addNewOrder(OrdersTbl newOrder)
        {
            await _dbContext.OrdersTbls.AddAsync(newOrder);
            await _dbContext.SaveChangesAsync();
            return newOrder;


        }

    }
}
