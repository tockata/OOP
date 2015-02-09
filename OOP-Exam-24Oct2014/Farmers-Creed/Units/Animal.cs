namespace FarmersCreed.Units
{
    using Interfaces;

    public abstract class Animal : FarmUnit
    {
        private FoodType foodType;

        protected Animal(string id, int health, int productionQuantity, 
            ProductType productType, int healthEffect, FoodType foodType)
            : base(id, health, productionQuantity, productType, healthEffect)
        {
            this.foodType = foodType;
        }

        public FoodType FoodType
        {
            get { return this.foodType; }
        }

        public abstract void Eat(IEdible food, int quantity);

        public abstract void Starve();

        public override string ToString()
        {
            return base.ToString() + (this.IsAlive ? ", Health: " + this.Health : ", DEAD");
        }
    }
}
