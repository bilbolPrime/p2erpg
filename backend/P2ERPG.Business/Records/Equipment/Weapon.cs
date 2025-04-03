using BilbolStack.Boonamai.P2ERPG.Common.Enumeration;

namespace BilbolStack.Boonamai.P2ERPG.Business.Records.Equipment
{
    public record Weapon(int weaponId, long mintId, string wallet, WeaponType weaponType, int roll);
}
