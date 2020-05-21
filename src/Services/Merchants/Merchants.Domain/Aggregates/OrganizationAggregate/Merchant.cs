using Merchants.Domain.SeedWork;
using System.ComponentModel.DataAnnotations.Schema;

namespace Merchants.Domain.Aggregates.OrganizationAggregate
{
    public class Merchant : BaseAddress
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string CallToAction { get; set; }
        public string ShortDescription { get; set; }
        public string WebsiteUrl { get; set; }
        public string Phone { get; set; }
        public string OperatingHours { get; set; }
        public string ContactEmail { get; set; }

        /// <summary>
        /// Determines which merchant to display in search results if multiple locations returned
        /// </summary>
        public bool IsDefault { get; set; }

        /// <summary>
        /// Type of merchant
        /// </summary>
        public int MerchantTypeID { get; set; }
        [ForeignKey("MerchantTypeID")]
        public virtual MerchantType MerchantType { get; set; }

        /// <summary>
        /// Organization that the merchant is a part of
        /// </summary>
        public int OrganizationID { get; set; }
        [ForeignKey("OrganizationID")]
        public Organization Organization { get; set; }
    }
}
