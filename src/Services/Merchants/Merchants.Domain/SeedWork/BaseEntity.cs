using System;

namespace Merchants.Domain.SeedWork
{
    public class BaseEntity : Entity
    {
        public DateTime CreatedAt { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? ModifiedAt { get; set; }
        public string ModifiedBy { get; set; }
        public bool Active { get; set; }
        public BaseEntity()
        {
            //TODO: Move to save changes implementation in db context
            CreatedAt = DateTime.Now;
            Active = true;
        }
    }
}
