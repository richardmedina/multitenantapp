using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiTenantApi.Repositories.Types
{
    public interface IEntityType
    {
        Guid Id { get; set; }
    }
}
