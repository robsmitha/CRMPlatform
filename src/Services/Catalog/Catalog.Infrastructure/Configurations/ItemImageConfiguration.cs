using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Catalog.Infrastructure.Configurations
{
    public class ItemImageConfiguration : IEntityTypeConfiguration<ItemImage>
    {
        public void Configure(EntityTypeBuilder<ItemImage> config)
        {
            config.ToTable("ItemImages", CatalogContext.DEFAULT_SCHEMA);

            config.HasKey(o => o.ID);
            config.Ignore(b => b.DomainEvents);
        }
    }
}
