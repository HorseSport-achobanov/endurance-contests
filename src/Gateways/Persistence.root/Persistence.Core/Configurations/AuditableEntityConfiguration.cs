﻿using EnduranceContestManager.Domain.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EnduranceContestManager.Gateways.Persistence.Core.Configurations
{
    public class AuditableEntityConfiguration<TEntity> : IEntityTypeConfiguration<TEntity>
        where TEntity : AuditableEntity
    {
        public virtual void Configure(EntityTypeBuilder<TEntity> builder)
        {
            builder
                .Property(x => x.CreatedOn)
                .IsRequired();

            builder
                .Property(x => x.CreatedBy)
                .IsRequired();
        }
    }
}