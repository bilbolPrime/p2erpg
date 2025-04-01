using BilbolStack.Boonamai.P2ERPG.Business.Records.Equipment;

namespace BilbolStack.Boonamai.P2ERPG.Business.Managers.Shields
{
    public interface IShieldsManager
    {
        Task<Shield> GetAsync(int id, long mintId);
        Task<IEnumerable<Shield>> GetAsync(string wallet);
        Task UpdateAsync(Shield shield);
        Task UpdateAsync(IEnumerable<Shield> shields);
    }
}