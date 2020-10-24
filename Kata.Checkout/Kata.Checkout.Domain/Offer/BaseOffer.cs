using System.Collections.Generic;
using System.Linq;
using Kata.Checkout.Domain.Models;

namespace Kata.Checkout.Domain.Offer
{
    public abstract class BaseOffer : IOffer
    {
        public OfferProduct ApplyOffer(IEnumerable<BasketProduct> products)
        {
            if (products == null || !products.Any())
            {
                return null;
            }
            
            var offerProduct = this.GetOffer(products.ToList());
            
            if (offerProduct != null)
            {
                foreach (var offeredProduct in offerProduct.ApplicableProducts)
                {
                    offeredProduct.IsApplied = true;
                }                
            }
            
            return offerProduct;
        }

        protected abstract OfferProduct GetOffer(List<BasketProduct> products);
    }
}