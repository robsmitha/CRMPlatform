using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Catalog.Infrastructure.Configurations
{
    public class PriceTypeConfiguration : IEntityTypeConfiguration<PriceType>
    {
        public void Configure(EntityTypeBuilder<PriceType> config)
        {
            config.ToTable("PriceTypes", CatalogContext.DEFAULT_SCHEMA);

            config.HasKey(o => o.ID);
            config.Ignore(b => b.DomainEvents);
        }
    }
}
