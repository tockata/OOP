namespace FarmersCreed.Units
{
    using System;

    public abstract class Plant : FarmUnit
    {
        private bool hasGrown = false;
        private int growTime;

        public Plant(string id, int health, int productionQuantity, int growTime,
            ProductType productType, int healthEffect)
            : base(id, health, productionQuantity, productType, healthEffect)
        {
            this.GrowTime = growTime;
        }

        public bool HasGrown
        {
            get
            {
                return this.hasGrown;
            }
            set
            {
                this.hasGrown = value;
            }
        }

        public int GrowTime
        {
            get
            {
                return this.growTime;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Grow time cannot be negative.");
                }

                this.growTime = value;
            }
        }

        public virtual void Water()
        {
            this.Health += 2;
        }

        public virtual void Wither()
        {
            this.Health--;
            if (this.Health <= 0)
            {
                this.IsAlive = false;
            }
        }

        public virtual void Grow()
        {
            if (this.GrowTime > 0)
            {
                this.GrowTime--;
            }
            else
            {
                this.hasGrown = true;
            }
        }

        public override string ToString()
        {
            return base.ToString() +
                (this.IsAlive ? ", Health: " + this.Health + ", Grown: " +
                (this.hasGrown ? "Yes" : "No") : ", DEAD");
        }
    }
}
