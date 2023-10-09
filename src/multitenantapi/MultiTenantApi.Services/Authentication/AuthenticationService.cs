using Microsoft.Extensions.Logging;
using MultiTenantApi.Common.Services;
using MultiTenantApi.Contract.Services.Authentication;
using MultiTenantApi.Contract.Services.User;
using MultiTenantApi.Infrastructure.JwtAuth;
using MultiTenantApi.Infrastructure.JwtAuth.Dto;
using MultiTenantApi.Infrastructure.Mfa;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiTenantApi.Services.Authentication
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly ILogger _logger;
        private readonly IUserService _userService;
        private readonly IJwtAuthService _jwtAuthService;
        private readonly IMfaService _mfaService;

        public AuthenticationService(
            ILogger<AuthenticationService> logger,
            IUserService userService,
            IJwtAuthService jwtAuthService,
            IMfaService mfaService)
        {
            _logger = logger;
            _userService = userService;
            _jwtAuthService = jwtAuthService;
            _mfaService = mfaService;
        }

        public async Task<AuthenticationResultDto> AuthenticateAsync(UserCredentialDto userCredential)
        {
            var user = await _userService.GetFromUserNameAsync(userCredential.UserName);
            if (user == null)
            {
                return new AuthenticationResultDto { IsSuccess = false };
            }

            return user.MfaRequired
                ? await mfaAuthenticateUserAsync(userCredential, user)
                :await authenticateUserAsync(userCredential, user);
        }

        public async Task<MfaDataDto> GenerateMfaData(UserCredentialDto userCredential)
        {
            var qrCode = await _mfaService.GenerateQrCodeDataAsync(userCredential.UserName);

            return new MfaDataDto
            {
                Secret = qrCode.Secret,
                Text = qrCode.Text,
                Base64EncodedImage = qrCode.Base64EncodedImage,
                ImageByteArray = qrCode.ImageByteArray
            };
        }

        private async Task<AuthenticationResultDto> mfaAuthenticateUserAsync(UserCredentialDto userCredential, UserDto user)
        {
            if (await _mfaService.ValidateCodeAsync(user.MfaSecret, userCredential.MfaCode))
            {
                return await authenticateUserAsync(userCredential, user);
            }

            return new AuthenticationResultDto { IsSuccess = false };
        }
        private async Task<AuthenticationResultDto> authenticateUserAsync(UserCredentialDto userCredential, UserDto user)
        {
            if (user != null && user.Password == userCredential.Password)
            {
                var result = await _jwtAuthService.AuthenticateAsync(new JwtAuthenticateData
                {
                    UserId = user.Id,
                    Email = user.Email,
                    UserName = user.UserName,
                    FirstName = user.FirstName,
                    LastName = user.LastName
                });

                if (result != null)
                {
                    return new AuthenticationResultDto
                    {
                        IsSuccess = true,
                        Token = result.Token
                    };
                }
            }

            return new AuthenticationResultDto
            {
                IsSuccess = false
            };
        }
    }
}
