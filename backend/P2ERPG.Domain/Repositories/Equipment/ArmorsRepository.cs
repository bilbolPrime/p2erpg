using BilbolStack.Boonamai.P2ERPG.Common.Options;
using BilbolStack.Boonamai.P2ERPG.Domain.Entities.Equipment;
using Microsoft.Extensions.Options;
using MoreLinq;

namespace BilbolStack.Boonamai.P2ERPG.Domain.Repositories.Equipment
{
    public class ArmorsRepository : BaseRepository<Armor>, IArmorsRepository
    {
        private const string GET_ARMORS = "[P2ERPG].[armors_get]";
        private const string UPDATE_ARMORS = "[P2ERPG].[armors_update]";

        public ArmorsRepository(IOptions<DBSettings> dbSettings) : base(dbSettings)
        {

        }

        public virtual async Task<Armor> GetAsync(int armorId, long mintId)
        {
            var param = new
            {
                armorId,
                mintId,
                wallet = string.Empty
            };

            return (await GetList(GET_ARMORS, param)).FirstOrDefault();
        }

        public virtual async Task<IEnumerable<Armor>> GetAsync(string wallet)
        {
            var param = new
            {
                armorId = -1,
                mintId = -1,
                wallet
            };

            return await GetList(GET_ARMORS, param);
        }

         public virtual async Task UpdateAsync(IEnumerable<Armor> armors)
        {
            var param = new
            {
                armors = armors.ToDataTable()
            };

            await Execute(UPDATE_ARMORS, param);
        }

        public virtual async Task UpdateAsync(Armor armor)
        {
            await UpdateAsync(new List<Armor>() { armor } );
        }
    }
}
