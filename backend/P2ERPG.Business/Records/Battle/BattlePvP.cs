using BilbolStack.Boonamai.P2ERPG.Business.Records.Characters;
using BilbolStack.Boonamai.P2ERPG.Common.Enumeration;

namespace BilbolStack.Boonamai.P2ERPG.Business.Records.Battle
{
    public record BattlePvP(Character attacker, WeaponType attWeaponType, ShieldType attShieldType, ArmorType attArmorType,
        Character defender, WeaponType defWeaponType, ShieldType defShieldType, ArmorType defArmorType);
}
