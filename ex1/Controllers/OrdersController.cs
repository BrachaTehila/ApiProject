using AutoMapper;
using DTO;
using Entities;
using Microsoft.AspNetCore.Mvc;
using Service;

namespace ex1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        
        private readonly IOrdersService _service;
        private readonly IMapper _mapper;

        public OrdersController(IOrdersService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        [HttpPost]
        public async Task<CreatedAtActionResult> Post([FromBody] OrderDTO orderDTO)
        {

            OrdersTbl order = _mapper.Map<OrderDTO, OrdersTbl>(orderDTO);
            OrdersTbl newOrder = await _service.addNewOrder(order);
            if (newOrder == null)
            {
                return null;
            }
            OrderDTO data = _mapper.Map<OrdersTbl, OrderDTO>(newOrder);
            return CreatedAtAction(nameof(Get), new { id = data.OrderId }, data);
        }
    }
}
