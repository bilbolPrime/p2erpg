using BilbolStack.Boonamai.P2ERPG.Business.Records.Characters;
using BilbolStack.Boonamai.P2ERPG.Common.Enumeration;

namespace BilbolStack.Boonamai.P2ERPG.Business.Records.Battle
{
    public record BattlePvE
    {
        public Character Attacker { get; init; }
        public WeaponType AttWeaponType { get; init; }
        public ShieldType AttShieldType { get; init; }
        public ArmorType AttArmorType { get; init; }
        public PvETarget Target { get; init; }

        public BattlePvE(Character attacker, WeaponType attWeaponType, ShieldType attShieldType, ArmorType attArmorType, PvETarget target)
        {
            Attacker = attacker;
            AttWeaponType = attWeaponType;
            AttShieldType = attShieldType;
            AttArmorType = attArmorType;
            Target = target;
        }
    }
}
