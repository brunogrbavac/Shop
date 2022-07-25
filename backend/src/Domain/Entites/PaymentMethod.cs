using Domain.Common;
using System.Collections.Generic;

namespace Domain.Entites
{
    public class PaymentMethod : AuditableEntity
    {
        public int PaymentMethodId { get; set; }
        public string Name { get; set; }

        public List<Order> Orders { get; set; }
    }
}
