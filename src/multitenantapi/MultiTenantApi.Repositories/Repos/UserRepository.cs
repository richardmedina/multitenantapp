﻿using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MultiTenantApi.Common.Repositories;
using MultiTenantApi.Contract.Domain;
using MultiTenantApi.Repositories.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiTenantApi.Repositories.Repos
{
    public class UserRepository : RepositoryBase<UserEntity, UserDomain>, IUserRepository
    {
        public UserRepository(MultiTenantApiDbContext context, IMapper mapper) : base(context, mapper)
        {
        }
    }
}
