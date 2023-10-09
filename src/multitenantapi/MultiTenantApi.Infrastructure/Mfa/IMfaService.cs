using MultiTenantApi.Infrastructure.Mfa.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiTenantApi.Infrastructure.Mfa
{
    public interface IMfaService
    {
        Task<bool> ValidateCodeAsync(string userName, string code);
        Task<QrCodeData> GenerateQrCodeDataAsync(string userName, string secret = "");
    }
}
