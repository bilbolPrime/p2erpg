using BilbolStack.Boonamai.P2ERPG.Common.Options;
using BilbolStack.Boonamai.P2ERPG.Domain.Entities.Equipment;
using Microsoft.Extensions.Options;

namespace BilbolStack.Boonamai.P2ERPG.Domain.Repositories.Equipment
{
    public class ArmorsMockRepository : ArmorsRepository
    {

        public ArmorsMockRepository(IOptions<DBSettings> dbSettings) : base(dbSettings)
        {

        }


        public override async Task<Armor> GetAsync(int id, long mintId)
        {
            return new Armor() { Id = id, MintId = mintId, EquipmentType = id % 3, Wallet = mintId.ToString() };
        }

        public override async Task<IEnumerable<Armor>> GetAsync(string wallet)
        {
            return new List<Armor>()
            {
                new Armor() { Wallet = wallet, EquipmentType = 0, Id = 1, MintId = 1, Roll = 1 },
                new Armor() { Wallet = wallet, EquipmentType = 1, Id = 2, MintId = 2, Roll = 2 },
                new Armor() { Wallet = wallet, EquipmentType = 2, Id = 3, MintId = 3, Roll = 3 },
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
    }
}
