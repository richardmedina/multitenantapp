using MultiTenantApi.Infrastructure.Data.Constants;
using MultiTenantApi.Infrastructure.Data.Types;
using System.ComponentModel.DataAnnotations.Schema;

namespace MultiTenantApi.Infrastructure.Data.Entities
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
        #endregion
    }

}
