using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Catalog.Infrastructure.Configurations
{
    public class ItemTypeConfiguration : IEntityTypeConfiguration<ItemType>
    {
        public void Configure(EntityTypeBuilder<ItemType> config)
        {
            config.ToTable("ItemTypes", CatalogContext.DEFAULT_SCHEMA);

            config.HasKey(o => o.ID);
            config.Ignore(b => b.DomainEvents);
        }
    }
}
