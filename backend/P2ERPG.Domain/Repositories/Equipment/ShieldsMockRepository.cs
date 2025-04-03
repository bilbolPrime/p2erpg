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


        public override async Task<Shield> GetAsync(int shieldId, long mintId)
        {
            return new Shield() { ShieldId = shieldId, MintId = mintId, ShieldType = shieldId % 3, Wallet = mintId.ToString() };
        }

        public override async Task<IEnumerable<Shield>> GetAsync(string wallet)
        {
            return new List<Shield>()
            {
                new Shield() { Wallet = wallet, ShieldType = 0, ShieldId = 1, MintId = 1, Roll = 1 },
                new Shield() { Wallet = wallet, ShieldType = 1, ShieldId = 2, MintId = 2, Roll = 2 },
                new Shield() { Wallet = wallet, ShieldType = 2, ShieldId = 3, MintId = 3, Roll = 3 },
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
