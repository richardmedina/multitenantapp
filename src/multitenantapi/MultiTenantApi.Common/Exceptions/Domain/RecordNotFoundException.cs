using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiTenantApi.Common.Exceptions.Domain
{
    public class RecordNotFoundException : Exception
    {
        public RecordNotFoundException() : base ("Record Not Found")
        {
        }
    }
}
