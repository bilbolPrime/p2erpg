using BilbolStack.Boonamai.P2ERPG.Common.Enumeration;

namespace BilbolStack.Boonamai.P2ERPG.Domain.Business.Equipment
{
    public record Armor(int id, long mintId, string wallet, ArmorType equipmentType, int roll);
}
