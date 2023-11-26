using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StorageManagement.Core.Domain.Entities;
using StorageManagement.Core.Domain.ValueObjects;

namespace StorageManagement.Infrastructure.Persistence.Configurations
{
    public class GateEntryConfiguration : IEntityTypeConfiguration<GateEntry>
    {
        public void Configure(EntityTypeBuilder<GateEntry> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Id).HasConversion(
                gateEntryId => gateEntryId.Value,
                value => new GateEntryId(value))
                .ValueGeneratedOnAdd();

            builder.Property(g =>g.EntryReference).HasMaxLength(500);
        }
    }
}
