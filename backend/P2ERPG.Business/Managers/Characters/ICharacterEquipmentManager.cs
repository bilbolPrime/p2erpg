using BilbolStack.Boonamai.P2ERPG.Business.Records.Characters;

namespace BilbolStack.Boonamai.P2ERPG.Business.Managers.Characters
{
    public interface ICharacterEquipmentManager
    {
        Task<CharacterAssignedEquipment> GetAsync(int characterId);
        Task UpdateAsync(CharacterAssignedEquipment characterAssignedEquipment);
    }
}