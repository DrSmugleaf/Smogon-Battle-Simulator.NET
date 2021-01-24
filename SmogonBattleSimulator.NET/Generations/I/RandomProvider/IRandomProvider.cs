namespace SmogonBattleSimulator.NET.Generations.I.RandomProvider
{
    public interface IRandomProvider
    {
        int RandomInteger(int maxExclusive);

        int RandomInteger(int minInclusive, int maxExclusive);

        float RandomFloat(float min, float max);

        double RandomDouble();

        double RandomDouble(double min, double max);

        decimal RandomDecimal(decimal min, decimal max);

        byte RandomByte();
    }
}
