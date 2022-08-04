using Framework.Core.Domain;
using Framework.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Framework.Persistence
{
    public abstract class EntityMappingBase<TEntity> : IEntityTypeConfiguration<TEntity>
        where TEntity : class, IEntityBase
    {
        public abstract void Configure(EntityTypeBuilder<TEntity> builder);


        protected void Initial(EntityTypeBuilder<TEntity> builder)
        {
            var a = typeof(TEntity);
            var baseClassName = typeof(EntityBase<>).Name;
            if (a.BaseType != null && a.BaseType.Name == baseClassName && a.IsClass /*&& !a.IsAbstract*/)
            {
                builder.Property("Id")
                    .HasColumnType(nameof(SqlDbType.BigInt))
                    .ValueGeneratedNever()
                    .HasDefaultValueSql("NEXT VALUE FOR shared." + typeof(TEntity).Name);

                builder.HasKey("Id");
            }

            builder.ToTable(typeof(TEntity).Name, typeof(TEntity).Namespace?.Split('.')[0]);
        }
    }
}
