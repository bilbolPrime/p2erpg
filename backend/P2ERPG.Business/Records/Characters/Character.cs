using BilbolStack.Boonamai.P2ERPG.Common.Enumeration;

namespace BilbolStack.Boonamai.P2ERPG.Business.Records.Characters
{
    public record Character(int characterId, long mintId, string wallet, CharacterType characterType, int hp, int strength, int speed, int agility, int concentration, int endurance, int experience, int level);
}}
