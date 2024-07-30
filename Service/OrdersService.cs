using DTO;
using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class OrdersService : IOrdersService
    {
        private readonly ILogger<OrdersService> _logger;
        private readonly IOrderRepository _repository;
        private readonly IProductRepository _productRepository;
        public OrdersService(IOrderRepository repository, IProductRepository productRepository, ILogger<OrdersService> logger)
        {
            _repository = repository;
            _productRepository = productRepository;
            _logger = logger;
        }

        public async Task<OrdersTbl> addNewOrder(OrdersTbl newOrder)
        {
            if (newOrder.UserId != null)
            {
                int[] ids = new int[newOrder.OrderItemTbls.Count()];
                for (int i = 0; i < newOrder.OrderItemTbls.Count(); i++)
                {
                    ids[i] = (int)newOrder.OrderItemTbls.ElementAt(i).ProductId;
                }

                IEnumerable<int> prices = await _productRepository.getPricesById(ids);
                int sum = 0;
                for (int i = 0; i < prices.Count(); i++)
                {
                    sum += prices.ElementAt(i);
                }
                if (sum != newOrder.OrderSum)
                {

                    _logger.LogInformation("someone try to still");
                    _logger.LogError("someone try to still");
                    return null;
                }
                return await _repository.addNewOrder(newOrder);
            }
            return null;




        }


    }
}
