namespace SmogonBattleSimulator.NET.Generations.I.Pokemon.Species.Stat
{
    public interface ISpeciesStat
    {
        StatType StatType { get; }

        int Value { get; }
    }
}
