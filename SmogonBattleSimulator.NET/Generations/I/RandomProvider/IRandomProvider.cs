namespace SmogonBattleSimulator.NET.Generations.I.RandomProvider
{
    public interface IRandomProvider
    {
        int RandomInteger(int min, int max);

        float RandomFloat(float min, float max);

        double RandomDouble(double min, double max);

        decimal RandomDecimal(decimal min, decimal max);
    }
}
