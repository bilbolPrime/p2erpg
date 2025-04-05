using BilbolStack.Boonamai.P2ERPG.Domain.Entities.Equipment;

namespace BilbolStack.Boonamai.P2ERPG.Domain.Repositories.Equipment
{
    public interface IArmorsRepository
    {
        Task<Armor> GetAsync(int armorId, long mintId);
        Task<IEnumerable<Armor>> GetAsync(string wallet);
        Task UpdateAsync(IEnumerable<Armor> armors);
        Task UpdateAsync(Armor armor);
    }
}