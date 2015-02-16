namespace Infestation
{
    public class AggressionCatalyst : Catalysts
    {
        private const int AggressionCatalystPowerEffect = 0;
        private const int AggressionCatalystHealthEffect = 0;
        private const int AggressionCatalystAggressionEffect = 3;

        public AggressionCatalyst()
            : base(AggressionCatalystPowerEffect, AggressionCatalystHealthEffect, AggressionCatalystAggressionEffect)
        {
        }
    }
}
