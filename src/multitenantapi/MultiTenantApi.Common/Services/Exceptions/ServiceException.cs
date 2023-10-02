using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiTenantApi.Common.Services.Exceptions
{
    public class ServiceException : Exception
    {
        public ServiceException(string message, Exception? exception) : base(message, exception)
        {
        }
    }
}
