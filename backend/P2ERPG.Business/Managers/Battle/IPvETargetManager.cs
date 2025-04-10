using BilbolStack.Boonamai.P2ERPG.Business.Records.Characters;
using BilbolStack.Boonamai.P2ERPG.Common.Enumeration;

namespace BilbolStack.Boonamai.P2ERPG.Business.Managers.Battle
{
    public interface IPvETargetManager
    {
        Character GetTarget(PvETarget target);
        ArmorType GetArmorType(PvETarget target);
        ShieldType GetShieldType(PvETarget target);
        WeaponType GetWeaponType(PvETarget target);
    }
}