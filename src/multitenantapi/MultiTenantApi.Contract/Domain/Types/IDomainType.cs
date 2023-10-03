using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiTenantApi.Contract.Domain.Types
{
    public interface IDomainType
    {
        Guid Id { get; set; }
    }
}
