using BilbolStack.Boonamai.P2ERPG.Common.Options;
using BilbolStack.Boonamai.P2ERPG.Domain.Entities.Equipment;
using Microsoft.Extensions.Options;

namespace BilbolStack.Boonamai.P2ERPG.Domain.Repositories.Equipment
{
    public class ArmorsRepository : BaseRepository<Armor>, IArmorsRepository
    {
        private const string GET_ARMORS = "";
        private const string GET_ARMOR = "";


        public ArmorsRepository(IOptions<DBSettings> dbSettings) : base(dbSettings)
        {

        }

        public virtual async Task<Armor> GetAsync(int id, long mintId)
        {
            var param = new
            {
                id,
                mintId
            };

            return (await GetList(GET_ARMORS, param)).FirstOrDefault();
        }

        public virtual async Task<IEnumerable<Armor>> GetAsync(string wallet)
        {
            var param = new
            {
                wallet
            };

            return await GetList(GET_ARMORS, param);
        }

        public virtual async Task UpdateAsync(IEnumerable<Armor> armors)
        {
            throw new NotImplementedException();
        }
    }
}
