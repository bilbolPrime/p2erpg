using BilbolStack.Boonamai.P2ERPG.Common.Options;
using BilbolStack.Boonamai.P2ERPG.Domain.Entities.Equipment;
using Microsoft.Extensions.Options;
using MoreLinq;

namespace BilbolStack.Boonamai.P2ERPG.Domain.Repositories.Equipment
{
    public class ShieldsRepository : BaseRepository<Shield>, IShieldsRepository
    {
        private const string GET_SHIELDS = "[P2ERPG].[shields_get]";
        private const string UPDATE_SHIELDS = "[P2ERPG].[shields_update]";

        public ShieldsRepository(IOptions<DBSettings> dbSettings) : base(dbSettings)
        {

        }

        public virtual async Task<Shield> GetAsync(int shieldId, long mintId)
        {
            var param = new
            {
                shieldId,
                mintId,
                wallet = string.Empty
            };

            return (await GetList(GET_SHIELDS, param)).FirstOrDefault();
        }

        public virtual async Task<IEnumerable<Shield>> GetAsync(string wallet)
        {
            var param = new
            {
                shieldId = -1,
                mintId = -1,
                wallet
            };

            return await GetList(GET_SHIELDS, param);
        }

        public virtual async Task UpdateAsync(IEnumerable<Shield> shields)
        {
            var param = new
            {
                shields = shields.ToDataTable()
            };

            await Execute(UPDATE_SHIELDS, param);
        }

        public virtual async Task UpdateAsync(Shield shield)
        {
            await UpdateAsync(new List<Shield>() { shield });
        }
    }
}
