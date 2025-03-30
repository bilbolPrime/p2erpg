using BilbolStack.Boonamai.P2ERPG.Domain.Entities.Equipment;

namespace BilbolStack.Boonamai.P2ERPG.Domain.Repositories.Equipment
{
    public interface IWeaponsRepository
    {
        Task<Weapon> GetAsync(int id, long mintId);
        Task<IEnumerable<Weapon>> GetAsync(string wallet);
        Task UpdateAsync(IEnumerable<Weapon> weapons);
    }
}