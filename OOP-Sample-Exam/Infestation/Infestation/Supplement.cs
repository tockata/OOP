﻿namespace Infestation
{
    public abstract class Supplement : ISupplement
    {
        protected int powerEffect;
        protected int healthEffect;
        protected int aggressionEffect;

        protected Supplement(int powerEffect, int healthEffect, int aggressionEffect)
        {
            this.powerEffect = powerEffect;
            this.healthEffect = healthEffect;
            this.aggressionEffect = aggressionEffect;
        }

        public virtual void ReactTo(ISupplement otherSupplement)
        {
        }

        public int PowerEffect
        {
            get { return this.powerEffect; }
        }

        public int HealthEffect
        {
            get { return this.healthEffect; }
        }

        public int AggressionEffect
        {
            get { return this.aggressionEffect; }
        }
    }
}
