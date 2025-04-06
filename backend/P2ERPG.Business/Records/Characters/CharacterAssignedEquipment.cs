using BilbolStack.Boonamai.P2ERPG.Common.Enumeration;

namespace BilbolStack.Boonamai.P2ERPG.Business.Records.Characters
{
    public record CharacterAssignedEquipment(int characterId, int? weaponId, int? armorId, int? shieldId);
}
