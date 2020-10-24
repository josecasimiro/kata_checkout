using System.Collections;
using System.Collections.Generic;
using Kata.Checkout.Domain.Models;
using Kata.Checkout.Domain.Offer;

namespace Kata.Checkout.Domain.Checkout
{
    public interface ICheckout
    {
        void Scan(Product product);
        decimal CalculateTotal(IEnumerable<IOffer> offers = null);
    }
}