using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using Kata.Checkout.Domain.Models;
using Kata.Checkout.Domain.Offer;

namespace Kata.Checkout.Domain.Checkout
{
    public class SimpleCheckout : ICheckout
    {
        private List<BasketProduct> _basket = new List<BasketProduct>();
        
        public void Scan(Product product)
        {
            if (product != null)
            {
                _basket.Add(new BasketProduct(product));
            }
        }

        public decimal CalculateTotal(IEnumerable<IOffer> offers = null)
        {
            if (offers != null)
            {
                this.ApplyOffers(offers);
            }

            return _basket.Sum(p => p.Price);
        }

        private void ApplyOffers(IEnumerable<IOffer> offers)
        {
            foreach (var offer in offers)
            {
                OfferProduct offerProduct;
                do
                {
                    offerProduct = offer.ApplyOffer(_basket.Where(p => !p.IsApplied));
                    if (offerProduct != null)
                    {
                        _basket.Add(offerProduct);
                    }
                } while (offerProduct != null);
            }
        }
    }
}