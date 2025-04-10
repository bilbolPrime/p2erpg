using BilbolStack.Boonamai.P2ERPG.Business.Records.Characters;
using BilbolStack.Boonamai.P2ERPG.Common.Enumeration;
using System.Reflection.Metadata.Ecma335;

namespace BilbolStack.Boonamai.P2ERPG.Business.Managers.Battle
{
    public class PvETargetManager : IPvETargetManager
    {
        public Character GetTarget(PvETarget target)
        {
            return target switch
            {
                PvETarget.WoodenDummy => new Character(1, 1, "Wooden Dummy", CharacterType.Other, 10, 0, 0, 0, 0, 0, 0, 0),
                PvETarget.Chicken => new Character(1, 1, "Chicken", CharacterType.Other, 15, 2, 1, 0, 0, 0, 0, 0),
                PvETarget.Dogo => new Character(1, 1, "Dogo", CharacterType.Other, 20, 3, 2, 0, 0, 0, 0, 0),
                PvETarget.DaphneBlake => new Character(1, 1, "Daphne Blake", CharacterType.Human, 25, 4, 3, 1, 1, 1, 0, 0),
                PvETarget.Thug => new Character(1, 1, "Thug", CharacterType.Human, 30, 5, 4, 2, 2, 2, 0, 0),
                PvETarget.Sellsword => new Character(1, 1, "Sellsword", CharacterType.Human, 35, 6, 5, 3, 3, 3, 0, 0),
                PvETarget.Uruk => new Character(1, 1, "Uruk", CharacterType.Orc, 40, 7, 6, 4, 4, 4, 0, 0),
                PvETarget.Legolas => new Character(1, 1, "Legolas", CharacterType.Elf, 45, 8, 7, 5, 5, 5, 0, 0),
                PvETarget.Batman => new Character(1, 1, "Batman", CharacterType.Human, 50, 9, 8, 6, 6, 6, 0, 0),
                _ => throw new ArgumentException($"Unknown PvE target: {target}")
            };
        }

        public ArmorType GetArmorType(PvETarget target)
        {
            return target switch
            {
                PvETarget.WoodenDummy => ArmorType.BirthdaySuit,
                PvETarget.Chicken => ArmorType.BirthdaySuit,
                PvETarget.Dogo => ArmorType.BirthdaySuit,
                PvETarget.DaphneBlake => ArmorType.Light,
                PvETarget.Thug => ArmorType.Light,
                PvETarget.Sellsword => ArmorType.Medium,
                PvETarget.Uruk => ArmorType.Heavy,
                PvETarget.Legolas => ArmorType.Medium,
                PvETarget.Batman => ArmorType.Heavy,
                _ => throw new ArgumentException($"Unknown PvE target: {target}")
            };
        }

        public ShieldType GetShieldType(PvETarget target)
        {
            return target switch
            {
                PvETarget.WoodenDummy => ShieldType.None,
                PvETarget.Chicken => ShieldType.None,
                PvETarget.Dogo => ShieldType.None,
                PvETarget.DaphneBlake => ShieldType.Small,
                PvETarget.Thug => ShieldType.Medium,
                PvETarget.Sellsword => ShieldType.Medium,
                PvETarget.Uruk => ShieldType.None,
                PvETarget.Legolas => ShieldType.Medium,
                PvETarget.Batman => ShieldType.None,
                _ => throw new ArgumentException($"Unknown PvE target: {target}")
            };
        }

        public WeaponType GetWeaponType(PvETarget target)
        {
            return target switch
            {
                PvETarget.WoodenDummy => WeaponType.Fists,
                PvETarget.Chicken => WeaponType.Fists,
                PvETarget.Dogo => WeaponType.Fists,
                PvETarget.DaphneBlake => WeaponType.Fists,
                PvETarget.Thug => WeaponType.Mace,
                PvETarget.Sellsword => WeaponType.Sword,
                PvETarget.Uruk => WeaponType.TwoHandedMace,
                PvETarget.Legolas => WeaponType.Bow,
                PvETarget.Batman => WeaponType.TwoHandedSword,
                _ => throw new ArgumentException($"Unknown PvE target: {target}")
            };
        }
    }
} 