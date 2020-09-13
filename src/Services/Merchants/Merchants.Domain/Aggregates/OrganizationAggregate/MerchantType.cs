using Shared.Domain.SeedWork;
using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel;
using System.Linq;

namespace Merchants.Domain.Aggregates.OrganizationAggregate
{
    public enum MerchantTypeEnum 
    { 
        [Description("Dry Cleaners")]
        DryCleaners = 1,
        [Description("Food Delivery")]
        FoodDelivery = 2,
        [Description("Store Pick up")]
        StorePickup = 3,
        [Description("Lawn Care")]
        LawnCare = 4,
        [Description("House Cleaning")]
        HouseCleaning = 5
    };
    public class MerchantType : BaseType<MerchantTypeEnum>
    {
        public MerchantType() : base()
        {

        }
        public MerchantType(MerchantTypeEnum @enum) : base(@enum)
        {
                
        }
        public static implicit operator MerchantType(MerchantTypeEnum @enum)
            => new MerchantType(@enum);

        public static implicit operator MerchantTypeEnum(MerchantType entity)
            => (MerchantTypeEnum)entity.ID;
    }
    /*
     public class MerchantType// : BaseType<MerchantTypeEnum>
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        protected MerchantType() { }
        protected MerchantType(MerchantTypeEnum @enum)
        {
            ID = @enum.EnumToInt();
            Name = @enum.ToString();
            Description = @enum.GetEnumDescription();
        }

        public static implicit operator MerchantType(MerchantTypeEnum @enum)
            => new MerchantType(@enum);

        public static implicit operator MerchantTypeEnum(MerchantType entity)
            => (MerchantTypeEnum)entity.ID;
    }
     */
}
