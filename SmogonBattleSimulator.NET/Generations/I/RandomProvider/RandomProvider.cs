using System;

namespace SmogonBattleSimulator.NET.Generations.I.RandomProvider
{
    public class RandomProvider : IRandomProvider
    {
        private readonly Random _random;

        public RandomProvider(int seed)
        {
            _random = new Random(seed);
        }

        public RandomProvider()
        {
            _random = new Random();
        }

        public int RandomInteger(int min, int max)
        {
            return _random.Next(min, max);
        }

        public float RandomFloat(float min, float max)
        {
            return (float) RandomDouble(min, max);
        }

        public double RandomDouble(double min, double max)
        {
            if (min > max)
            {
                throw new ArgumentOutOfRangeException($"Min ({min}) cannot be bigger than max ({max})");
            }

            return _random.NextDouble() * (max - min) + min;
        }

        public decimal RandomDecimal(decimal min, decimal max)
        {
            return (decimal) RandomDouble((double) min, (double) max);
        }
    }
}
