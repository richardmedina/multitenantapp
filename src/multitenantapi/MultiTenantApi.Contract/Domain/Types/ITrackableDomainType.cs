using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiTenantApi.Contract.Domain.Types
{
    public interface ITrackableDomainType
    {
        Guid CreatedBy { get; set; }
        DateTime CreatedTimestamp { get; set; }
        Guid UpdatedBy { get; set; }
        DateTime UpdatedTimestamp { get; set; }
    }
}
