using Domain.Common;
using System.Collections.Generic;

namespace Domain.Entites
{
    public class Brand : AuditableEntity
    {
        public int BrandId { get; set; }
        public string Name { get; set; }

        public List<Product> Products { get; set; } 
    }
}
