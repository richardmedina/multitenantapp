using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiTenantApi.Common.Services.Exceptions
{
    public class NotFoundServiceException : ServiceException
    {
        public NotFoundServiceException(Exception ex) : base("NotFoundServiceException", ex)
        {
        }
    }
}
