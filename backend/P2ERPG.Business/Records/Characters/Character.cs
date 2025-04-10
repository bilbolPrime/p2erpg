using BilbolStack.Boonamai.P2ERPG.Common.Enumeration;

namespace BilbolStack.Boonamai.P2ERPG.Business.Records.Characters
{
    public class Character
    {
        public int Id { get; init; }
        public int UserId { get; init; }
        public string Name { get; init; }
        public CharacterType CharacterType { get; init; }
        public int Hp { get; init; }
        public int Strength { get; init; }
        public int Defense { get; init; }
        public int Speed { get; init; }
        public int Agility { get; init; }
        public int Concentration { get; init; }
        public int Magic { get; init; }
        public int Resistance { get; init; }

        public Character(int id, int userId, string name, CharacterType characterType, int hp, int strength, int defense, int speed, int agility, int concentration, int magic, int resistance)
        {
            Id = id;
            UserId = userId;
            Name = name;
            CharacterType = characterType;
            Hp = hp;
            Strength = strength;
            Defense = defense;
            Speed = speed;
            Agility = agility;
            Concentration = concentration;
            Magic = magic;
            Resistance = resistance;
        }
    }
}
