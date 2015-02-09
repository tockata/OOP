using System;

namespace FarmersCreed.Units
{
    public class TobaccoPlant : Plant
    {
        private const int TobaccoHealth = 12;
        private const int TobaccoGrowTime = 4;
        private const int ProductionQuantity = 10;
        private const ProductType PrType = ProductType.Tobacco;
        private const int HealthEffect = 0;

        public TobaccoPlant(string id)
            : base(id, TobaccoHealth, ProductionQuantity, TobaccoGrowTime, PrType, HealthEffect)
        {
        }

        public override void Grow()
        {

            if (this.GrowTime <= 0)
            {
                this.HasGrown = true;
            }
            else
            {
                this.GrowTime -= 2;
            }
        }

        public override Product GetProduct()
        {
            if (this.IsAlive && this.HasGrown)
            {
                return new Product(this.Id + "Product", PrType, ProductionQuantity);
            }

            throw new ArgumentException("TobbacoPlant is not alive or is still growing!");
        }
    }
}
