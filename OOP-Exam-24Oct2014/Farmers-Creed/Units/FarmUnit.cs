using FarmersCreed.Interfaces;

namespace FarmersCreed.Units
{
    using System;

    public abstract class FarmUnit : GameObject, IProductProduceable
    {
        private int health;
        private bool isAlive = true;
        private int productionQuantity;
        private int healthEffect;

        protected FarmUnit(string id, int health, int productionQuantity, 
            ProductType productType, int healthEffect)
            : base(id)
        {
            this.Health = health;
            this.ProductionQuantity = productionQuantity;
            this.ProductType = productType;
            this.healthEffect = healthEffect;
        }

        public int Health
        {
            get
            {
                return this.health;
            }
            set
            {
                this.health = value;
            }
        }

        public bool IsAlive
        {
            get
            {
                return this.isAlive;
            }
            set
            {
                this.isAlive = value;
            }
        }

        public int ProductionQuantity
        {
            get
            {
                return this.productionQuantity;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Product quantity cannot be negative.");
                }

                this.productionQuantity = value;
            }
        }

        public ProductType ProductType { get; set; }

        public int HealthEffect
        {
            get
            {
                return this.healthEffect;
            }
        }

        public abstract Product GetProduct();
    }
}
