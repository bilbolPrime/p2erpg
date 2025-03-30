using BilbolStack.Boonamai.P2ERPG.Common.Enumeration;

namespace BilbolStack.Boonamai.P2ERPG.Domain.Business.Equipment
{
    public record Shield(int id, long mintId, string wallet, ShieldType equipmentType, int roll);
}
