using System.Collections.Generic;
using System.Linq;
using Kata.Checkout.Domain.Models;

namespace Kata.Checkout.Domain.Offer
{
    public class MealDealOffer : BaseOffer
    {
        public MealDealOffer(int drinkProductId, int foodProductId, int sideProductId, decimal flatPrice)
        {
            this.DrinkProductId = drinkProductId;
            this.FoodProductId = foodProductId;
            this.SideProductId = sideProductId;
            this.MealDealPrice = flatPrice;
        }

        public decimal MealDealPrice { get; set; }

        public int SideProductId { get; set; }

        public int FoodProductId { get; set; }

        public int DrinkProductId { get; set; }

        protected override OfferProduct GetOffer(List<BasketProduct> products)
        {
            var applicableDrink = products.FirstOrDefault(p => p.Id == this.SideProductId);
            var applicableFood = products.FirstOrDefault(p => p.Id == this.FoodProductId);
            var applicableSide = products.FirstOrDefault(p => p.Id == this.DrinkProductId);

            if (applicableDrink == null || applicableFood == null || applicableSide == null)
            {
                return null;
            }

            var applicableProducts = new List<BasketProduct> {applicableDrink, applicableFood, applicableSide};
            var total = applicableProducts.Sum(p => p.Price);
            var discountPrice = total > this.MealDealPrice ? this.MealDealPrice - total : total;
            
            return new OfferProduct(applicableProducts, this.MealDealPrice - total);
        }
    }
}