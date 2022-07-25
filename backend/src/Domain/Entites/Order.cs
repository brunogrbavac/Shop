using Domain.Common;
using System;
using System.Collections.Generic;

namespace Domain.Entites
{
    public class Order : AuditableEntity
    {
        public int OrderId { get; set; } 
        public float PricePreTax  { get; set; }
        public float PriceAfterTax { get; set; }
        public string CardNumber { get; set; }  
        public string Email { get; set; }   
        public DateTime Date { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; } 
        public string Message { get; set; } 

        public int DiscountCodeId { get; set; }
        public int PaymentMethodId { get; set; }
        public PaymentMethod PaymentMethod { get; set; }    

        public ICollection<Product> Products { get; set; }
    }
}
