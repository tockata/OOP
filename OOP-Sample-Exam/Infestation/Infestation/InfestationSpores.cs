using System;

namespace Infestation
{
    public class InfestationSpores : Supplement
    {
        private const int InfestationSporesPowerEffect = -1;
        private const int InfestationSporesHealthEffect = 0;
        private const int InfestationSporesAggressionEffect = 20;

        public InfestationSpores()
            : base(InfestationSporesPowerEffect, InfestationSporesHealthEffect, InfestationSporesAggressionEffect)
        {
        }

        public override void ReactTo(ISupplement otherSupplement)
        {
            if (otherSupplement.GetType().Name == "InfestationSpores")
            {
                this.aggressionEffect = 0;
                this.powerEffect = 0;
            }
        }
    }
}
