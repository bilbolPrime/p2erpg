using BilbolStack.Boonamai.P2ERPG.Business.Records;
using BilbolStack.Boonamai.P2ERPG.Business.Records.Equipment;

namespace BilbolStack.Boonamai.P2ERPG.Business.Managers.Equipment.Shields
{
    public interface IShieldsManager
    {
        Task<Shield> GetAsync(int id, long mintId);
        Task<IEnumerable<Shield>> GetAsync(string wallet);
        Task UpdateAsync(Shield shield);
        Task UpdateAsync(IEnumerable<Shield> shields);
        Task UpdateAsync(IEnumerable<NFTOwnership> nFTOwnerships);
    }
}