using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using StorageManagement.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StorageManagement.Core.Domain.ValueObjects;

namespace StorageManagement.Infrastructure.Persistence.Configurations
{
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Id).HasConversion(
                customerId => customerId.Value,
                value => new CustomerId(value))
                .ValueGeneratedOnAdd();

            builder.Property(g => g.Name).HasMaxLength(1000);

            builder.Property(g => g.Pan).HasMaxLength(100);

            builder.ComplexProperty
                          (p => p.ContactPerson, contactPersonbuilder =>
                          {
                              contactPersonbuilder.Property(p => p.Name).IsRequired(false).HasMaxLength(100);
                              contactPersonbuilder.Property(p => p.PhoneNumber).IsRequired(false).HasMaxLength(20);
                          });

            builder.ComplexProperty
                       (p => p.Address, addressbuilder =>
                       {
                           addressbuilder.Property(a => a.Street).IsRequired(false).HasMaxLength(1000);
                           addressbuilder.Property(a => a.City).IsRequired(false).HasMaxLength(100);
                           addressbuilder.Property(a => a.Pincode).IsRequired(false).HasMaxLength(6);
                       });

            builder.Ignore(g => g.CreatedBy);
            builder.Ignore(g => g.CreatedDate);
            builder.Ignore(g => g.UpdatedDate);
            builder.Ignore(g => g.UpdatedBy);
        }
    }
}
