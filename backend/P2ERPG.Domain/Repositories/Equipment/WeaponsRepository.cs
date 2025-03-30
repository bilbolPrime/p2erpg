using BilbolStack.Boonamai.P2ERPG.Common.Options;
using BilbolStack.Boonamai.P2ERPG.Domain.Entities.Equipment;
using Microsoft.Extensions.Options;

namespace BilbolStack.Boonamai.P2ERPG.Domain.Repositories.Equipment
{
    public class WeaponsRepository : BaseRepository<Weapon>, IWeaponsRepository
    {
        private const string GET_WEAPONS = "";
        private const string GET_WEAPON = "";


        public WeaponsRepository(IOptions<DBSettings> dbSettings) : base(dbSettings)
        {

        }

        public virtual async Task<Weapon> GetAsync(int id, long mintId)
        {
            var param = new
            {
                id,
                mintId
            };

            return (await GetList(GET_WEAPON, param)).FirstOrDefault();
        }

        public virtual async Task<IEnumerable<Weapon>> GetAsync(string wallet)
        {
            var param = new
            {
                wallet
            };

            return await GetList(GET_WEAPONS, param);
        }

        public virtual async Task UpdateAsync(IEnumerable<Weapon> weapons)
        {
            throw new NotImplementedException();
        }
    }
}
