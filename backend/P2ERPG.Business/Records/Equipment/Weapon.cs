using BilbolStack.Boonamai.P2ERPG.Common.Enumeration;

namespace BilbolStack.Boonamai.P2ERPG.Business.Records.Equipment
{
    public record Weapon(int id, long mintId, string wallet, WeaponType equipmentType, int roll);
}
