using BilbolStack.Boonamai.P2ERPG.Common.Options;
using BilbolStack.Boonamai.P2ERPG.Domain.Entities.Equipment;
using Microsoft.Extensions.Options;

namespace BilbolStack.Boonamai.P2ERPG.Domain.Repositories.Equipment
{
    public class WeaponsMockRepository : WeaponsRepository
    {

        public WeaponsMockRepository(IOptions<DBSettings> dbSettings) : base(dbSettings)
        {

        }


        public override async Task<Weapon> GetAsync(int id, long mintId)
        {
            return new Weapon() { Id = id, MintId = mintId, EquipmentType = id % 3, Wallet = mintId.ToString()};
        }

        public override async Task<IEnumerable<Weapon>> GetAsync(string wallet)
        {
            return new List<Weapon>()
            {
                new Weapon() { Wallet = wallet, EquipmentType = 0, Id = 1, MintId = 1, Roll = 1 },
                new Weapon() { Wallet = wallet, EquipmentType = 1, Id = 2, MintId = 2, Roll = 2 },
                new Weapon() { Wallet = wallet, EquipmentType = 2, Id = 3, MintId = 3, Roll = 3 },
            };
        }

        public override async Task UpdateAsync(IEnumerable<Weapon> weapons)
        {
            await Task.CompletedTask;
        }
    }
}
