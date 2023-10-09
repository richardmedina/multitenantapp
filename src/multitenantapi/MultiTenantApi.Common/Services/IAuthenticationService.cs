using MultiTenantApi.Contract.Services.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiTenantApi.Common.Services
{
    public interface IAuthenticationService
    {
        Task<AuthenticationResultDto> AuthenticateAsync(UserCredentialDto userCredential);
        Task<MfaDataDto> GenerateMfaData(UserCredentialDto userCredential);
    }
}
