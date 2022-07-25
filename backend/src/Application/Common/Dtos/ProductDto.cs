using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Common.Dtos
{
    public class ProductDto
    {
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public float Price { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string BrandName { get; set; }
        public int BrandId { get; set; }
    }
}
