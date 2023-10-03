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
