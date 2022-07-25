using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Common.Dtos
{
    public class DiscountCodeDto
    {
        public int DiscountCodeId { get; set; }
        public string Code { get; set; }
        public float Discount { get; set; }
        public bool Used { get; set; }
        public int OrderId { get; set; }
    }
}
