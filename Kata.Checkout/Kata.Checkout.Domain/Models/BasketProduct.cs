using System;
using System.Collections.Generic;
using System.Linq;

namespace Kata.Checkout.Domain.Models
{
    public class BasketProduct : Product
    {
        public BasketProduct(Product product) 
            : base(product.Id, product.Name, product.Price)
        {
        }        
        
        public bool IsApplied { get; set; }
    }
}