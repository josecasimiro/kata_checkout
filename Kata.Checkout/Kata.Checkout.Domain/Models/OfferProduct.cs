using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Kata.Checkout.Domain.Models
{
    public class OfferProduct : BasketProduct
    {
        private OfferProduct(Product product) 
            : base(product)
        {
        }
        
        public OfferProduct(IEnumerable<BasketProduct> products, decimal offerPrice) 
            : base(products.FirstOrDefault())
        {
            this.Price = offerPrice;
            this.ApplicableProducts = products;
            this.IsApplied = true;
        }
        
        public IEnumerable<BasketProduct> ApplicableProducts { get; protected set; }

    }
}