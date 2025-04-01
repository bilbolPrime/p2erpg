using BilbolStack.Boonamai.P2ERPG.Common.Options;
using BilbolStack.Boonamai.P2ERPG.Domain.Entities.Equipment;
using Microsoft.Extensions.Options;

namespace BilbolStack.Boonamai.P2ERPG.Domain.Repositories.Equipment
{
    public class ShieldsMockRepository : ShieldsRepository
    {

        public ShieldsMockRepository(IOptions<DBSettings> dbSettings) : base(dbSettings)
        {

        }


        public override async Task<Shield> GetAsync(int id, long mintId)
        {
            return new Shield() { Id = id, MintId = mintId, EquipmentType = id % 3, Wallet = mintId.ToString() };
        }

        public override async Task<IEnumerable<Shield>> GetAsync(string wallet)
        {
            return new List<Shield>()
            {
                new Shield() { Wallet = wallet, EquipmentType = 0, Id = 1, MintId = 1, Roll = 1 },
                new Shield() { Wallet = wallet, EquipmentType = 1, Id = 2, MintId = 2, Roll = 2 },
                new Shield() { Wallet = wallet, EquipmentType = 2, Id = 3, MintId = 3, Roll = 3 },
            };
        }

        public override async Task UpdateAsync(IEnumerable<Shield> shields)
        {
            await Task.CompletedTask;
        }

        public override async Task UpdateAsync(Shield shield)
        {
            await Task.CompletedTask;
        }
    }
}
