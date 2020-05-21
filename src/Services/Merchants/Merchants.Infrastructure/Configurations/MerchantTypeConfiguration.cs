using Merchants.Domain.Aggregates.OrganizationAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Merchants.Infrastructure.Configurations
{
    public class MerchantTypeConfiguration
     : IEntityTypeConfiguration<MerchantType>
    {
        public void Configure(EntityTypeBuilder<MerchantType> config)
        {
            config.ToTable("MerchantTypes", MerchantsContext.DEFAULT_SCHEMA);

            config.HasKey(o => o.ID);
            //config.Ignore(b => b.DomainEvents);
        }
    }
}
