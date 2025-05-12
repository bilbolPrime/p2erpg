using BilbolStack.Boonamai.P2ERPG.Common.Options;
using BilbolStack.Boonamai.P2ERPG.Domain.Entities;
using BilbolStack.Boonamai.P2ERPG.Domain.Entities.Equipment;
using Microsoft.Extensions.Options;

namespace BilbolStack.Boonamai.P2ERPG.Domain.Repositories.Equipment
{
    public class ArmorsMockRepository : ArmorsRepository
    {

        public ArmorsMockRepository(IOptions<DBSettings> dbSettings) : base(dbSettings)
        {

        }


        public override async Task<Armor> GetAsync(int armorId, long mintId)
        {
            return new Armor() { ArmorId = armorId, MintId = mintId, ArmorType = armorId % 3, Wallet = mintId.ToString() };
        }

        public override async Task<IEnumerable<Armor>> GetAsync(string wallet)
        {
            return new List<Armor>()
            {
                new Armor() { Wallet = wallet, ArmorType = 0, ArmorId = 1, MintId = 1, Roll = 1 },
                new Armor() { Wallet = wallet, ArmorType = 1, ArmorId = 2, MintId = 2, Roll = 2 },
                new Armor() { Wallet = wallet, ArmorType = 2, ArmorId = 3, MintId = 3, Roll = 3 },
            };
        }

        public override async Task UpdateAsync(IEnumerable<Armor> armors)
        {
            await Task.CompletedTask;
        }

        public override async Task UpdateAsync(Armor armor)
        {
            await Task.CompletedTask;
        }

        public override async Task UpdateAsync(IEnumerable<NFTOwnership> nFTOwnerships)
        {
            await Task.CompletedTask;
        }
    }
}
