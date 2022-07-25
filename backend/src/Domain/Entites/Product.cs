using Domain.Common;
using System.Collections.Generic;

namespace Domain.Entites
{
    public class Product : AuditableEntity
    {
        public int ProductId { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }
        public float Price { get; set; }
        public int Quantity { get; set; }

        public int BrandId { get; set; }
        public Brand Brand { get; set; }
        public ICollection<Order> Orders { get; set; }
    }
}
