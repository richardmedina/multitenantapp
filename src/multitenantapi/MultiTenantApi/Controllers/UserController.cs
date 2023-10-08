using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using MultiTenantApi.Common.Services;
using MultiTenantApi.Contract.Services.User;
using MultiTenantApi.Models.User;

namespace MultiTenantApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        private readonly IUserService _userService;
        private readonly IMapper _mapper;
        public UserController(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateUserModel createUserModel)
        {
            var userDto = _mapper.Map<UserDto>(createUserModel);

            var createdUser = await _userService.CreateAsync(userDto);

            return Ok(createdUser);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var users = _mapper.Map<IEnumerable<UserModel>>(await _userService.GetAllAsync());

            return Ok(users);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var userDto = _mapper.Map<UserModel>(await _userService.GetAsync(id));

            return userDto == null ? NotFound() : Ok(userDto);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _userService.DeleteAsync(id);

            return result ? Ok() : NotFound();
        }
    }
}
