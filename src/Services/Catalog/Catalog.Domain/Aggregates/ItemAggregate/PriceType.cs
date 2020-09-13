using Shared.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public enum PriceTypeEnum
    {
        [Description("Fixed")]
        Fixed = 1,
        [Description("Variable")]
        Variable = 2
    };
    public class PriceType : BaseType<PriceTypeEnum>
    {
        /// <summary>
        /// TODO: implment PricingModel that maps variable cost logic 
        /// (i.e buy one get one, custom pricing model flows )
        /// </summary>
        //public int PricingModelID { get; set; }
        public PriceType() : base()
        {

        }
        public PriceType(PriceTypeEnum @enum) : base(@enum)
        {

        }
        public static implicit operator PriceType(PriceTypeEnum @enum)
            => new PriceType(@enum);

        public static implicit operator PriceTypeEnum(PriceType entity)
            => (PriceTypeEnum)entity.ID;
    }
}
