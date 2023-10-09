using MultiTenantApi.Infrastructure.Data.Constants;
using MultiTenantApi.Infrastructure.Data.Types;
using System.ComponentModel.DataAnnotations.Schema;

namespace MultiTenantApi.Infrastructure.Data.Entities
{
    [Table(TableNames.Users)]
    public class UserEntity : IEntityType
    {
        public Guid Id { get; set; }
        public string Email { get; set; } = string.Empty;
        public string UserName { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public bool MfaRequired { get; set; }
        public string MfaSecret { get; set; } = string.Empty;
    }
}
