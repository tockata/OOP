using FarmersCreed.Units;

namespace FarmersCreed
{
    public abstract class FoodPlant : Plant
    {
        private const FoodType FType = FoodType.Organic;

        protected FoodPlant(string id, int health, int productionQuantity,
            int growTime, ProductType productType, int healthEffect)
            : base (id, health, productionQuantity, growTime, productType, healthEffect)
        {
        }

        public FoodType FoodType
        {
            get { return FType; }
        }

        public override void Water()
        {
            this.Health += 1;
        }

        public override void Wither()
        {
            if (this.Health > 0)
            {
                this.Health -= 2;
            }
            else
            {
                this.IsAlive = false;
            }
        }
    }
}
