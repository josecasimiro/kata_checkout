using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Kata.Checkout.Domain.Models;

namespace Kata.Checkout.Domain.Offer
{
    public class MultiPackOffer : BaseOffer
    {
        public MultiPackOffer(int productId, decimal discount, int productCount)
        {
            this.ProductId = productId;
            this.Discount = discount;
            this.ProductCount = productCount;
        }

        public int ProductCount { get; }

        public decimal Discount { get; }

        public int ProductId { get; }

        protected override OfferProduct GetOffer(List<BasketProduct> products)
        {
            var applicableProducts = products.Where(p => p.Id == this.ProductId).ToList();
            if (applicableProducts.Count < this.ProductCount)
            {
                return null;
            }

            applicableProducts = applicableProducts.Take(this.ProductCount).ToList();
            var total = applicableProducts.Sum(p => p.Price);
            
            return new OfferProduct(applicableProducts, (total * this.Discount) - total);
        }
    }
}