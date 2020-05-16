namespace ModularShips
{
    public class EnergyUsage
    {
        public int Rate { get; }
        public int Workload { get; set; }

        public EnergyUsage(int rate)
        {
            Rate = rate;
            Workload = 0;
        }
    }
}
