using Domain.Entites;
using System;
using System.Collections.Generic;

namespace Application.Common.Dtos
{
    public class OrderDto
    {
        public int OrderId { get; set; }
        public float PricePreTax { get; set; }
        public float PriceAfterTax { get; set; }
        public string CardNumber { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string Message { get; set; }
        public DateTime Date { get; set; }

        public List<Product> Products { get; set; } 

    }
}
