using BilbolStack.Boonamai.P2ERPG.Common.Enumeration;

namespace BilbolStack.Boonamai.P2ERPG.Business.Records.Equipment
{
    public record Armor(int armorId, long mintId, string wallet, ArmorType armorType, int roll);
}
