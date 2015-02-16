namespace Infestation
{
    public class PowerCatalyst : Catalysts
    {
        private const int PowerCatalystPowerEffect = 3;
        private const int PowerCatalystHealthEffect = 0;
        private const int PowerCatalystAggressionEffect = 0;

        public PowerCatalyst() 
            : base(PowerCatalystPowerEffect, PowerCatalystHealthEffect, PowerCatalystAggressionEffect)
        {
        }
    }
}
