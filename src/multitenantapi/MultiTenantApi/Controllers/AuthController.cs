using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MultiTenantApi.Common.Services;
using MultiTenantApi.Contract.Services.Authentication;
using MultiTenantApi.Infrastructure.JwtAuth;
using MultiTenantApi.Infrastructure.JwtAuth.Dto;
using MultiTenantApi.Models.Auth;

namespace MultiTenantApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthenticationService _authenticationService;
        private readonly IMapper _mapper;
        public AuthController(
            IAuthenticationService authenticationService,
            IUserService userService,
            IMapper mapper)
        {
            _authenticationService = authenticationService;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> Authenticate([FromBody] UserCredentialModel userCredential)
        {
            var usercredentialDto = _mapper.Map<UserCredentialDto>(userCredential);

            var authenticationResult = await _authenticationService.AuthenticateAsync(usercredentialDto);

            return authenticationResult.IsSuccess
                ? Ok(authenticationResult.Token)
                : Unauthorized();   
        }
    }
}
