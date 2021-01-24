using System;

namespace SmogonBattleSimulator.NET.Generations.I.RandomProvider
{
    public class RandomGenerator : IRandomProvider
    {
        private readonly Random _random;

        public RandomGenerator(int seed)
        {
            _random = new Random(seed);
        }

        public RandomGenerator()
        {
            _random = new Random();
        }

        public int RandomInteger(int maxExclusive)
        {
            if (maxExclusive < 0)
            {
                throw new ArgumentOutOfRangeException($"Min (0) cannot be bigger than max ({maxExclusive})");
            }

            return _random.Next(maxExclusive);
        }

        public int RandomInteger(int minInclusive, int maxExclusive)
        {
            if (minInclusive > maxExclusive)
            {
                throw new ArgumentOutOfRangeException($"Min ({minInclusive}) cannot be bigger than max ({maxExclusive})");
            }

            return _random.Next(minInclusive, maxExclusive);
        }

        public float RandomFloat(float min, float max)
        {
            return (float) RandomDouble(min, max);
        }

        public double RandomDouble()
        {
            return _random.NextDouble();
        }

        public double RandomDouble(double min, double max)
        {
            if (min > max)
            {
                throw new ArgumentOutOfRangeException($"Min ({min}) cannot be bigger than max ({max})");
            }

            return RandomDouble() * (max - min) + min;
        }

        public decimal RandomDecimal(decimal min, decimal max)
        {
            return (decimal) RandomDouble((double) min, (double) max);
        }

        public byte RandomByte()
        {
            var bytes = new byte[1];
            _random.NextBytes(bytes);
            return bytes[0];
        }
    }
}
