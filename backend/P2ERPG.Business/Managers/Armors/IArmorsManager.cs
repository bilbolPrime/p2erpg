using BilbolStack.Boonamai.P2ERPG.Business.Records.Equipment;

namespace BilbolStack.Boonamai.P2ERPG.Business.Managers.Armors
{
    public interface IArmorsManager
    {
        Task<Armor> GetAsync(int id, long mintId);
        Task<IEnumerable<Armor>> GetAsync(string wallet);
        Task UpdateAsync(Armor armor);
        Task UpdateAsync(IEnumerable<Armor> armors);
    }
}