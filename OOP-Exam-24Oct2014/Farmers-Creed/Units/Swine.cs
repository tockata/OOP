using System;

namespace FarmersCreed.Units
{
    public class Swine : Animal
    {
        private const int SwineHealth = 20;
        private const int ProductionQuantity = 1;
        private const ProductType PrType = ProductType.PorkMeat;
        private const int HealthEffect = 5;
        private const FoodType FType = FoodType.Meat;

        public Swine(string id)
            : base(id, SwineHealth, ProductionQuantity, PrType, HealthEffect, FType)
        {
        }

        public override void Eat(Interfaces.IEdible food, int quantity)
        {
            var fq = ((Food)food).Quantity;
            if (fq >= quantity)
            {
                food.Quantity -= quantity;
                this.Health += food.HealthEffect * 2 * quantity;
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
                this.IsAlive = false;
                return new Food(this.Id + "Product", PrType, FType, ProductionQuantity, HealthEffect);
            }

            throw new ArgumentException("Swine is not alive!");
        }

        public override void Starve()
        {
            if (this.Health > 0)
            {
                this.Health -= 3;
            }

            if (this.Health <= 0)
            {
                this.IsAlive = false;
            }
        }
    }
}
