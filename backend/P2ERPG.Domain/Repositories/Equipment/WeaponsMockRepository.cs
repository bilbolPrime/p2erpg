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


        public override async Task<Weapon> GetAsync(int weaponId, long mintId)
        {
            return new Weapon() { WeaponId = weaponId, MintId = mintId, WeaponType = weaponId % 3, Wallet = mintId.ToString()};
        }

        public override async Task<IEnumerable<Weapon>> GetAsync(string wallet)
        {
            return new List<Weapon>()
            {
                new Weapon() { Wallet = wallet, WeaponType = 0, WeaponId = 1, MintId = 1, Roll = 1 },
                new Weapon() { Wallet = wallet, WeaponType = 1, WeaponId = 2, MintId = 2, Roll = 2 },
                new Weapon() { Wallet = wallet, WeaponType = 2, WeaponId = 3, MintId = 3, Roll = 3 },
            };
        }

        public override async Task UpdateAsync(IEnumerable<Weapon> weapons)
        {
            await Task.CompletedTask;
        }

        public override async Task UpdateAsync(Weapon weapon)
        {
            await Task.CompletedTask;
        }
    }
}
