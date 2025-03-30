using BilbolStack.Boonamai.P2ERPG.Common.Options;
using BilbolStack.Boonamai.P2ERPG.Domain.Entities.Equipment;
using Microsoft.Extensions.Options;

namespace BilbolStack.Boonamai.P2ERPG.Domain.Repositories.Equipment
{
    public class ArmorRepository : BaseRepository<Armor>, IArmorRepository
    {
        private const string GET_ARMOR_S = "";
        private const string GET_ARMOR = "";


        public ArmorRepository(IOptions<DBSettings> dbSettings) : base(dbSettings)
        {

        }

        public virtual async Task<Armor> GetAsync(int id, long mintId)
        {
            var param = new
            {
                id,
                mintId
            };

            return (await GetList(GET_ARMOR, param)).FirstOrDefault();
        }

        public virtual async Task<IEnumerable<Armor>> GetAsync(string wallet)
        {
            var param = new
            {
                wallet
            };

            return await GetList(GET_ARMOR_S, param);
        }

        public virtual async Task UpdateAsync(IEnumerable<Armor> armor)
        {
            throw new NotImplementedException();
        }
    }
}
