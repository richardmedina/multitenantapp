using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiTenantApi.Contract.Services.Authentication
{
    public class UserCredentialDto
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string MfaCode {  get; set; }
    }
}
