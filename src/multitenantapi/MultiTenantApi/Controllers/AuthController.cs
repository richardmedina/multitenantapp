using Microsoft.AspNetCore.Mvc;
using MultiTenantApi.Common.Services;
using MultiTenantApi.Infrastructure.JwtAuth;
using MultiTenantApi.Infrastructure.JwtAuth.Dto;
using MultiTenantApi.Models.Auth;

namespace MultiTenantApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IJwtAuthService _jwtAuthService;
        private readonly IUserService _userService;
        public AuthController(IJwtAuthService jwtAuthService, IUserService userService)
        {
            _jwtAuthService = jwtAuthService;
            _userService = userService;
        }
        [HttpPost]
        public async Task<IActionResult> Authenticate([FromBody] UserCredentialsModel userCredentials)
        {
            var user = await _userService.GetFromUserNameAsync(userCredentials.UserName);

            if(user != null && userCredentials.UserName == user.UserName && userCredentials.Password == user.Password)
            {
                var authenticatedUser = await _jwtAuthService.AuthenticateAsync(new JwtAuthenticateData
                {
                    UserId = user.Id,
                    UserName = user.UserName,
                    Email = user.Email,
                    FirstName = user.FirstName,
                    LastName = user.LastName
                });

                if (authenticatedUser != null)
                {
                    var userToken = new UserTokenModel
                    {
                        Token = authenticatedUser.Token
                    };

                    return Ok(userToken);
                }
            }

            return Unauthorized();  
        }

        [HttpDelete]
        public void DeAuthenticate()
        {

        }
    }
}
