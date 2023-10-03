using MultiTenantApi.Repositories.Constants;
using MultiTenantApi.Repositories.Types;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiTenantApi.Repositories.Entities
{
    [Table(TableNames.Items)]
    public class ItemEntity : IEntityType, ITrackableEntityType
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

    #region ITrackableEntity
        public Guid CreatedBy { get; set; }
        public DateTime CreatedTimestamp { get; set; }
        public Guid UpdatedBy { get; set; }
        public DateTime UpdatedTimestamp { get; set; }
    }
    #endregion
}
