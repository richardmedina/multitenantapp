﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MultiTenantApi.Contract.Domain.Types;

namespace MultiTenantApi.Contract.Domain
{
    public class UserDomain : IDomainType
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public bool MfaRequired { get; set; }
        public string MfaSecret { get; set; }
    }
}
