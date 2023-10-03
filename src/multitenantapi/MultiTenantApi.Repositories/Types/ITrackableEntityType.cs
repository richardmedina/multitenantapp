using MultiTenantApi.Repositories.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiTenantApi.Repositories.Types
{
    public interface ITrackableEntityType
    {
        Guid CreatedBy { get; set; }
        DateTime CreatedTimestamp { get; set; }
        Guid UpdatedBy { get; set; }
        DateTime UpdatedTimestamp { get; set; }
    }
}
