using System.Collections.Generic;
using Kata.Checkout.Domain.Models;

namespace Kata.Checkout.Domain.Offer
{
    public interface IOffer
    {
        OfferProduct ApplyOffer(IEnumerable<BasketProduct> products);
    }
}