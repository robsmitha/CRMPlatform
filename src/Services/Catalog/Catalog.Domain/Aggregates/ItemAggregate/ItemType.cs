using Shared.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public enum ItemTypeEnum
    {
        [Description("Laundry")]
        Laundry = 1,
        [Description("Suit")]
        Suit = 2,
        [Description("Dress")]
        Dress = 3,
        [Description("Alteration")]
        Alteration = 4,
        [Description("Subscription")]
        Subscription = 5
    };
    public class ItemType : BaseType<ItemTypeEnum>
    {
        public ItemType() : base()
        {

        }
        public ItemType(ItemTypeEnum @enum) : base(@enum)
        {

        }
        public static implicit operator ItemType(ItemTypeEnum @enum)
            => new ItemType(@enum);

        public static implicit operator ItemTypeEnum(ItemType entity)
            => (ItemTypeEnum)entity.ID;
    }
}
