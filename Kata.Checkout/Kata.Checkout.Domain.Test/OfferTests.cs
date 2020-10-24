using System.Collections.Generic;
using System.Linq;
using Kata.Checkout.Domain.Models;
using Kata.Checkout.Domain.Offer;
using NUnit.Framework;

namespace Kata.Checkout.Domain.Test
{
    [TestFixture]
    public class OfferTests
    {
        [Test]
        public void Given_MealDealProducts_AndOthers_When_ApplyingOffer_Then_OfferProductIsCreated_AndGivenProductsAreApplied()
        {
            // Arrange
            const decimal cDrinkPrice = 300.5m;
            const decimal cFoodPrice = 513.2m;
            const decimal cSidePrice = 50m;
            const decimal cMealDealPrice = 200m;
            
            var drinkProduct = new BasketProduct(new Product(1, "Juice", cDrinkPrice));
            var foodProduct = new BasketProduct(new Product(2, "Chicken Wrap", cFoodPrice));
            var sideProduct = new BasketProduct(new Product(3, "Crisps", cSidePrice));
            var otherProduct = new BasketProduct(new Product(4, "Other", 100m));
            var products = new List<BasketProduct>() {drinkProduct, foodProduct, sideProduct,otherProduct};
            
            // Act 
            var mealDealOffer = new MealDealOffer(1,2,3, cMealDealPrice);
            var offerProduct = mealDealOffer.ApplyOffer(products);
            
            // Assert
            Assert.IsNotNull(offerProduct?.ApplicableProducts);
            Assert.IsTrue(offerProduct.IsApplied);
            Assert.AreEqual(3, offerProduct.ApplicableProducts.Count());
            Assert.IsTrue(offerProduct.ApplicableProducts.Contains(drinkProduct));
            Assert.IsTrue(drinkProduct.IsApplied);
            Assert.IsTrue(offerProduct.ApplicableProducts.Contains(foodProduct));
            Assert.IsTrue(foodProduct.IsApplied);
            Assert.IsTrue(offerProduct.ApplicableProducts.Contains(sideProduct));
            Assert.IsTrue(sideProduct.IsApplied);
            Assert.IsFalse(offerProduct.ApplicableProducts.Contains(otherProduct));
            Assert.IsFalse(otherProduct.IsApplied);
            Assert.AreEqual(cMealDealPrice - (cDrinkPrice + cFoodPrice + cSidePrice), offerProduct.Price);
        }
    }
}