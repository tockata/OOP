using FarmersCreed.Units;
using System;

namespace FarmersCreed
{
    public class CherryTree : FoodPlant
    {
        private const int CherryTreeHealth = 14;
        private const int CherryTreeGrowTime = 3;
        private const int ProductionQuantity = 4;
        private const ProductType PrType = ProductType.Cherry;
        private const int HealthEffect = 2;

        public CherryTree(string id)
            : base(id, CherryTreeHealth, ProductionQuantity, CherryTreeGrowTime, PrType, HealthEffect)
        {
        }

        public override Product GetProduct()
        {
            if (this.IsAlive)
            {
                return new Food(this.Id + "Product", PrType, FoodType.Organic, ProductionQuantity, HealthEffect);
            }

            throw new ArgumentException("CherryTree is not alive!");
        }

        public override void Wither()
        {
            this.Health -= 2;
            if (this.Health <= 0)
            {
                this.IsAlive = false;
            }
        }
    }
}
