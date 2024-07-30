using AutoMapper;
using DTO;
using Entities;
using Microsoft.AspNetCore.Mvc;
using Service;

namespace ex1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {

        private readonly IProductService _service;
        private readonly IMapper _mapper;

        public ProductsController(IProductService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductDTO>>> Get( string? desc, int? minPrice, int? maxPrice, [FromQuery] int?[] categoriesId)
        {
            IEnumerable<Product> products= await _service.getAllProduct( desc,  minPrice,  maxPrice, categoriesId);
            IEnumerable<ProductDTO> productsDTO = _mapper.Map<IEnumerable<Product>, IEnumerable<ProductDTO>>(products);
            return Ok(productsDTO);
        }
    }
}
