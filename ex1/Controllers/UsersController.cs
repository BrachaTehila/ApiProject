using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc.Core.Infrastructure;
using Zxcvbn;
using Service;
using Entities;
using DTO;
using AutoMapper;

namespace ex1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {

        private readonly ILogger<UsersController> _logger;
        private readonly IUserService _service;
        private readonly IMapper _mapper;

        public UsersController(IUserService service, IMapper mapper, ILogger<UsersController> logger)
        {
            _service = service;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpPost("login")]
        public async Task<ActionResult<UsersTbl>> Post([FromBody] UserLoginDTO userLogin)
        {
            UsersTbl user = await _service.getUserByEmailAndPassword(userLogin);
            if (user == null)
                return NoContent();
            // logger.LogInformation("user login");
            return Ok(user);
        }

        [HttpGet("{id}")]
        public string Get()
        {
            return "value";
        }

        [HttpPost]
        public async Task<CreatedAtActionResult> Post([FromBody] UserDTO userDTO)
        {
            UsersTbl user = _mapper.Map<UserDTO, UsersTbl>(userDTO);
            UsersTbl newUser = await _service.addUser(user);
            if (newUser == null)
            {
                return null;
            }
            return CreatedAtAction(nameof(Get), new { id = newUser.UserId }, newUser);
        }

        [HttpPut("{id}")]
        public async Task Put([FromBody] UserDTO value)
        {
            UsersTbl user = _mapper.Map<UserDTO, UsersTbl>(value);
            await _service.updateUser(user);
        }

        [HttpPost("check")]
        public int Post([FromBody] string password)
        {
            return _service.checkPassword(password);
        }
    }
}
