using Merchants.Domain.SeedWork;

namespace Merchants.Domain.Aggregates.OrganizationAggregate
{
    public class Organization : BaseEntity, IAggregateRoot
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
