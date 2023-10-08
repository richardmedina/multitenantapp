using MultiTenantApi.Infrastructure.Data.Constants;
using MultiTenantApi.Infrastructure.Data.Types;
using System.ComponentModel.DataAnnotations.Schema;

namespace MultiTenantApi.Infrastructure.Data.Entities
{
    [Table(TableNames.Users)]
    public class UserEntity : IEntityType
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
    }
}
