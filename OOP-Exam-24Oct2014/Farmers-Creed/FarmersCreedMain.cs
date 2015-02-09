namespace FarmersCreed
{
    using Simulator;

    class FarmersCreedMain
    {
        static void Main()
        {
            FarmSimulator simulator = new UpdatedFarmSimulator();
            simulator.Run();
        }
    }
}
