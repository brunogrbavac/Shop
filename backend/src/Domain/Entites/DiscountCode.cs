using Domain.Common;

namespace Domain.Entites
{
    public class DiscountCode : AuditableEntity
    {
        public int DiscountCodeId { get; set; } 
        public string Code { get; set; }    
        public float Discount { get; set; }    
        public bool Used { get; set; }

        public int OrderId { get; set; }    
    }
}
