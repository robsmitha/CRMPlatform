using Shared.Domain.SeedWork;
using System.ComponentModel;

namespace Domain.Entities
{
    public enum UnitTypeEnum
    {
        [Description("Quantity")]
        Quantity = 1
    };
    public class UnitType : BaseType<UnitTypeEnum>
    {
        /// <summary>
        /// Abbreviation (i.e. 4 each)
        /// </summary>
        public string PerUnit { get; set; }
        public UnitType() : base()
        {

        }
        public UnitType(UnitTypeEnum @enum) : base(@enum)
        {

        }
        public static implicit operator UnitType(UnitTypeEnum @enum)
            => new UnitType(@enum);

        public static implicit operator UnitTypeEnum(UnitType entity)
            => (UnitTypeEnum)entity.ID;
    }
}
