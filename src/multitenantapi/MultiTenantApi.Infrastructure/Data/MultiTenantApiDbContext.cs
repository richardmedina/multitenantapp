﻿using Microsoft.EntityFrameworkCore;
using MultiTenantApi.Infrastructure.Data.Entities;

namespace MultiTenantApi.Infrastructure.Data
{
    public class MultiTenantApiDbContext : DbContext
    {
        public DbSet<UserEntity> Users { get; set; }
        public DbSet<ItemEntity> Items { get; set; }

        public MultiTenantApiDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserEntity>().HasData(
                new UserEntity
                {
                    Id = new Guid("DAB12EE2-8C61-4863-8D19-AEC3F278AE01"),
                    Email = "admin@admin.com",
                    UserName = "admin",
                    FirstName = "admin",
                    LastName = "admin",
                    Password = "admin"
                }
            );

            base.OnModelCreating(modelBuilder);
        }
    }
}
