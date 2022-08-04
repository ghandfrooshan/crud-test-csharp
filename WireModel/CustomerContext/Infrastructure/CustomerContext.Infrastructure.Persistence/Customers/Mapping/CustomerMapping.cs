using CustomerContext.Domain.Customers;
using Framework.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace CustomerContext.Infrastructure.Persistence.Customers.Mapping
{
    public class CustomerMapping : EntityMappingBase<Customer>
    {
        public override void Configure(EntityTypeBuilder<Customer> builder)
        {
            Initial(builder);
            builder.Property(a=>a.Id).HasColumnType(nameof(SqlDbType.BigInt));
            builder.Property(a=>a.FirstName).HasMaxLength(80);
            builder.Property(a=>a.LastName).HasMaxLength(150);
            builder.Property(a=>a.DateOfBirth).HasColumnType(nameof(SqlDbType.Date));
            builder.Property(a=>a.PhoneNumber).HasMaxLength(20);
            builder.Property(a=>a.Email).HasMaxLength(100);
            builder.Property(a=>a.BankAccountNumber).HasMaxLength(50);
        }
    }
}
