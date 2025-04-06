using BilbolStack.Boonamai.P2ERPG.Domain.Entities.Characters;

namespace BilbolStack.Boonamai.P2ERPG.Domain.Repositories.Characters
{
    public interface ICharacterAssignedEquipmentRepository
    {
        Task<CharacterAssignedEquipment> GetAsync(int characterId);
        Task UpdateAsync(CharacterAssignedEquipment characterAssignedEquipment);
    }
}