using BilbolStack.Boonamai.P2ERPG.Common.Enumeration;

namespace BilbolStack.Boonamai.P2ERPG.Business.Records.Equipment
{
    public record Armor(int id, long mintId, string wallet, ArmorType equipmentType, int roll);
}
