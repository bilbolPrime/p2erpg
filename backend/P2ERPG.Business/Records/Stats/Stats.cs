namespace BilbolStack.Boonamai.P2ERPG.Business.Records.Stats
{
    public class Stats
    {
        public int Health { get; init; }
        public int Strength { get; init; }
        public int Defense { get; init; }
        public int Speed { get; init; }
        public int Magic { get; init; }
        public int Resistance { get; init; }

        public Stats(int health, int strength, int defense, int speed, int magic, int resistance)
        {
            Health = health;
            Strength = strength;
            Defense = defense;
            Speed = speed;
            Magic = magic;
            Resistance = resistance;
        }
    }
} 