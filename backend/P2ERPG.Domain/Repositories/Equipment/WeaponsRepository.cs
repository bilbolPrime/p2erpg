using BilbolStack.Boonamai.P2ERPG.Common.Options;
using BilbolStack.Boonamai.P2ERPG.Domain.Entities.Equipment;
using Microsoft.Extensions.Options;
using MoreLinq;

namespace BilbolStack.Boonamai.P2ERPG.Domain.Repositories.Equipment
{
    public class WeaponsRepository : BaseRepository<Weapon>, IWeaponsRepository
    {
        private const string GET_WEAPONS = "[P2ERPG].[weapons_get]";
        private const string UPDATE_WEAPONS = "[P2ERPG].[weapons_update]";

        public WeaponsRepository(IOptions<DBSettings> dbSettings) : base(dbSettings)
        {

        }

        public virtual async Task<Weapon> GetAsync(int weaponId, long mintId)
        {
            var param = new
            {
                weaponId,
                mintId,
                wallet = string.Empty
            };

            return (await GetList(GET_WEAPONS, param)).FirstOrDefault();
        }

        public virtual async Task<IEnumerable<Weapon>> GetAsync(string wallet)
        {
            var param = new
            {
                weaponId = -1,
                mintId = -1,
                wallet
            };

            return await GetList(GET_WEAPONS, param);
        }

        public virtual async Task UpdateAsync(IEnumerable<Weapon> weapons)
        {
            var param = new
            {
                weapons = weapons.ToDataTable()
            };

            await Execute(UPDATE_WEAPONS, param);
        }

        public virtual async Task UpdateAsync(Weapon weapon)
        {
            await UpdateAsync(new List<Weapon>() { weapon });
        }
    }
}
