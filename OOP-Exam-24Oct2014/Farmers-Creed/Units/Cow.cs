using System;
using FarmersCreed.Interfaces;

namespace FarmersCreed.Units
{
    public class Cow : Animal
    {
        private const int CowHealth = 15;
        private const int ProductionQuantity = 6;
        private const ProductType PrType = ProductType.Milk;
        private const int HealthEffect = 4;
        private const FoodType FType = FoodType.Organic;

        public Cow(string id)
            : base(id, CowHealth, ProductionQuantity, PrType, HealthEffect, FType)
        {
        }

        public override void Eat(IEdible food, int quantity)
        {
            if (food.Quantity >= quantity)
            {
                food.Quantity -= quantity;
                if (food.FoodType == FoodType.Organic)
                {
                    this.Health += food.HealthEffect * quantity;
                }
                else
                {
                    this.Health -= food.HealthEffect * quantity;
                }
            }
            else
            {
                throw new ArgumentException("There is not enough quantity of food!");
            }
        }

        public override Product GetProduct()
        {
            if (this.IsAlive)
            {
                this.Health -= 2;
                var pr = new Food(this.Id + "Product", PrType, FType, ProductionQuantity, HealthEffect);
                return pr;
            }

            throw new ArgumentException("Cow is not alive!");
        }

        public override void Starve()
        {
            if (this.Health > 0)
            {
                this.Health--;
            }

            if (this.Health <= 0)
            {
                this.IsAlive = false;
            }
        }
    }
}
