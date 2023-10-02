using AutoMapper;
using Microsoft.AspNetCore.Mvc;
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


        [HttpGet("{userId}")]
        public async Task<IActionResult> Get(Guid userId)
        {
            var userDto = _mapper.Map<UserModel>(await _userService.GetAsync(userId));

            return userDto == null ? NotFound() : Ok(userDto);
        }
    }
}
