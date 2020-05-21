using Merchants.Domain.Aggregates.OrganizationAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Merchants.Infrastructure.Configurations
{
    public class OrganizationConfiguration
     : IEntityTypeConfiguration<Organization>
    {
        public void Configure(EntityTypeBuilder<Organization> organizationConfiguration)
        {
            organizationConfiguration.ToTable("Organizations", MerchantsContext.DEFAULT_SCHEMA);

            organizationConfiguration.HasKey(o => o.ID);
            organizationConfiguration.Ignore(b => b.DomainEvents);
        }
    }
}
