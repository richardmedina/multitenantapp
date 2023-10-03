using MultiTenantApi.Contract.Domain.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiTenantApi.Contract.Domain
{
    public class ItemDomain : IDomainType, ITrackableDomainType
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Guid CreatedBy { get; set; }
        public DateTime CreatedTimestamp { get; set; }
        public Guid UpdatedBy { get; set; }
        public DateTime UpdatedTimestamp { get; set; }
    }
}
