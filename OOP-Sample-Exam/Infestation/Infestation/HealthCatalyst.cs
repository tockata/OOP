namespace Infestation
{
    public class HealthCatalyst : Catalysts
    {
        private const int HealthCatalystPowerEffect = 0;
        private const int HealthCatalystHealthEffect = 3;
        private const int HealthCatalystAggressionEffect = 0;

        public HealthCatalyst()
            : base(HealthCatalystPowerEffect, HealthCatalystHealthEffect, HealthCatalystAggressionEffect)
        {
        }
    }
}
