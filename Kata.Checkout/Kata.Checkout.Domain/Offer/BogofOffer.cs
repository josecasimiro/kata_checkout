using System.Collections.Generic;
using Kata.Checkout.Domain.Models;

namespace Kata.Checkout.Domain.Offer
{
    public class BogofOffer : MultiPackOffer
    {
        public BogofOffer(int productId) : 
            base(productId, 0.5m, 2)
        {
        }
    }
}