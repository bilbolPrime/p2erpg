using BilbolStack.Boonamai.P2ERPG.Common.Options;
using BilbolStack.Boonamai.P2ERPG.Domain.Entities.Equipment;
using Microsoft.Extensions.Options;

namespace BilbolStack.Boonamai.P2ERPG.Domain.Repositories.Equipment
{
    public class ShieldsRepository : BaseRepository<Shield>, IShieldsRepository
    {
        private const string GET_SHIELDS = "";
        private const string GET_SHIELD = "";


        public ShieldsRepository(IOptions<DBSettings> dbSettings) : base(dbSettings)
        {

        }

        public virtual async Task<Shield> GetAsync(int id, long mintId)
        {
            var param = new
            {
                id,
                mintId
            };

            return (await GetList(GET_SHIELD, param)).FirstOrDefault();
        }

        public virtual async Task<IEnumerable<Shield>> GetAsync(string wallet)
        {
            var param = new
            {
                wallet
            };

            return await GetList(GET_SHIELDS, param);
        }

        public virtual async Task UpdateAsync(IEnumerable<Shield> shields)
        {
            throw new NotImplementedException();
        }

        public virtual async Task UpdateAsync(Shield shield)
        {
            await Task.CompletedTask;
        }
    }
}
