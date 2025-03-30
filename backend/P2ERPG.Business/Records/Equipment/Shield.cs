using BilbolStack.Boonamai.P2ERPG.Common.Enumeration;

namespace BilbolStack.Boonamai.P2ERPG.Business.Records.Equipment
{
    public record Shield(int id, long mintId, string wallet, ShieldType equipmentType, int roll);
}
