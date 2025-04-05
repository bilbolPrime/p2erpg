using BilbolStack.Boonamai.P2ERPG.Business.Records.Equipment;

namespace BilbolStack.Boonamai.P2ERPG.Business.Managers.Equipment.Weapons
{
    public interface IWeaponsManager
    {
        Task<Weapon> GetAsync(int id, long mintId);
        Task<IEnumerable<Weapon>> GetAsync(string wallet);
        Task UpdateAsync(Weapon weapon);
        Task UpdateAsync(IEnumerable<Weapon> weapons);
    }
}