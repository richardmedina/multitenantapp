using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiTenantApi.Contract.Services.Authentication
{
    public class AuthenticationResultDto
    {
        public bool IsSuccess { get; set; }
        public string? Token { get; set; }
    }
}
