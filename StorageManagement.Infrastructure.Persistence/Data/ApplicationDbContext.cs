﻿using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StorageManagement.Core.Domain.Entities;
using StorageManagement.Infrastructure.Persistence.Configurations;

namespace StorageManagement.Infrastructure.Persistence.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<GateEntry> GateEntries { get; set; }
        public DbSet<Customer> Customers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new GateEntryConfiguration());
            modelBuilder.ApplyConfiguration(new CustomerConfiguration());

        }
    }
}
