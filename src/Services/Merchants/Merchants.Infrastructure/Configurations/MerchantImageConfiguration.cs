using Merchants.Domain.Aggregates.OrganizationAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Merchants.Infrastructure.Configurations
{
    public class MerchantImageConfiguration
    : IEntityTypeConfiguration<MerchantImage>
    {
        public void Configure(EntityTypeBuilder<MerchantImage> config)
        {
            config.ToTable("MerchantImages", MerchantsContext.DEFAULT_SCHEMA);

            config.HasKey(o => o.ID);
            config.Ignore(b => b.DomainEvents);
        }
    }
}
