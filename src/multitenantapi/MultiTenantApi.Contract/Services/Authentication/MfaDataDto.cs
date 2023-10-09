using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiTenantApi.Contract.Services.Authentication
{
    public class MfaDataDto
    {
        public string Secret { get; set; }
        public string Base64EncodedImage { get; set; }
        public string Text { get; set; }
        public byte[] ImageByteArray { get; set; }
    }
}
