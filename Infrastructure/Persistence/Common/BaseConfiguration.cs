using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using SwApi.Domain.Common;

namespace SwApi.Infrastructure.Persistence.Common;

public abstract class BaseConfiguration<TEntity> : IEntityTypeConfiguration<TEntity> where TEntity : BaseEntity
{
    public virtual void Configure(EntityTypeBuilder<TEntity> builder)
    {
        builder
            .HasKey(x => x.Id);

        builder
            .Property(p => p.ConcurrencyStamp)
            .IsConcurrencyToken();
    }
}
