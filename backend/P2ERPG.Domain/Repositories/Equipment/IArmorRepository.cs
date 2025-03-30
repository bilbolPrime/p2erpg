using BilbolStack.Boonamai.P2ERPG.Domain.Entities.Equipment;

namespace BilbolStack.Boonamai.P2ERPG.Domain.Repositories.Equipment
{
    public interface IArmorRepository
    {
        Task<Armor> GetAsync(int id, long mintId);
        Task<IEnumerable<Armor>> GetAsync(string wallet);
        Task UpdateAsync(IEnumerable<Armor> armor);
    }
}