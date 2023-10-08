using Microsoft.AspNetCore.Mvc;
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
        public AuthController(IJwtAuthService jwtAuthService)
        {
            _jwtAuthService = jwtAuthService;
        }
        [HttpPost]
        public async Task<IActionResult> Authenticate([FromBody] UserCredentialsModel userCredentials)
        {
            if(userCredentials.UserName == "admin" && userCredentials.Password == "admin")
            {
                var authenticatedUser = await _jwtAuthService.AuthenticateAsync(new JwtAuthenticateData
                {
                    UserId = Guid.NewGuid(),
                    UserName = "admin",
                    Email = "admin@domain.com",
                    FirstName = "Admin",
                    LastName = "Administrador"
                });

                var userToken = new UserTokenModel
                {
                    Token = authenticatedUser.Token
                };

                return Ok(userToken);
            }

            return Unauthorized();
        }
    }
}
