namespace Infestation
{
    public abstract class Catalysts : Supplement
    {
        protected Catalysts(int powerEffect, int healthEffect, int aggressionEffect) 
            : base(powerEffect, healthEffect, aggressionEffect)
        {
        }
    }
}
