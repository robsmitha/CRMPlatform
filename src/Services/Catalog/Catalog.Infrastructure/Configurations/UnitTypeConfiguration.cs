using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Catalog.Infrastructure.Configurations
{
    public class UnitTypeConfiguration : IEntityTypeConfiguration<UnitType>
    {
        public void Configure(EntityTypeBuilder<UnitType> config)
        {
            config.ToTable("UnitTypes", CatalogContext.DEFAULT_SCHEMA);

            config.HasKey(o => o.ID);
            config.Ignore(b => b.DomainEvents);
        }
    }
}
