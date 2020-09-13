using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Catalog.Infrastructure.Configurations
{
    public class ItemConfiguration : IEntityTypeConfiguration<Item>
    {
        public void Configure(EntityTypeBuilder<Item> config)
        {
            config.ToTable("Items", CatalogContext.DEFAULT_SCHEMA);

            config.HasKey(o => o.ID);
            config.Ignore(b => b.DomainEvents);
        }
    }
}
