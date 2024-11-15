﻿using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using SwApi.Domain.Common;

namespace SwApi.Infrastructure.Persistence.Common;

public abstract class Configuration<TEntity> : IEntityTypeConfiguration<TEntity> where TEntity : BaseEntity
{
    public virtual void Configure(EntityTypeBuilder<TEntity> builder)
    {
        builder
            .HasKey(entity => entity.Id);

        builder
            .Property(entity => entity.ConcurrencyStamp)
            .IsConcurrencyToken();
    }
}
