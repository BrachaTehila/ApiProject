using AutoMapper;
using DTO;
using Entities;
using Microsoft.AspNetCore.Mvc;
using Service;

namespace ex1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {

        private readonly IMapper _mapper;
        private ICategoryService _service;

        public CategoriesController(ICategoryService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategoriesDTO>>> Get()
        {
            IEnumerable<Category> categoriesList = await _service.getAllCategories();
            IEnumerable<CategoriesDTO> categoriesListDTO = _mapper.Map<IEnumerable<Category>, IEnumerable<CategoriesDTO>>(categoriesList);
            return Ok(categoriesListDTO);
        }
    }
}
