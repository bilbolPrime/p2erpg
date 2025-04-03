using BilbolStack.Boonamai.P2ERPG.Common.Options;
using BilbolStack.Boonamai.P2ERPG.Domain.Entities.Characters;
using Microsoft.Extensions.Options;
using MoreLinq;

namespace BilbolStack.Boonamai.P2ERPG.Domain.Repositories.Characters
{
    public class CharactersRepository : BaseRepository<Character>, ICharactersRepository
    {
        private const string GET_CHARACTERS = "";
        private const string UPDATE_CHARACTERS = "[P2ERPG].[characters_update]";

        public CharactersRepository(IOptions<DBSettings> dbSettings) : base(dbSettings)
        {

        }

        public virtual async Task UpdateAsync(Character character)
        {
            await UpdateAsync(new List<Character>() { character });
        }

        public virtual async Task<Character> GetAsync(int characterId, long mintId)
        {
            var param = new
            {
                characterId,
                mintId,
                wallet = string.Empty
            };

            return (await GetList(GET_CHARACTERS, param)).FirstOrDefault();
        }

        public virtual async Task<IEnumerable<Character>> GetAsync(string wallet)
        {
            var param = new
            {
                characterId = -1,
                mintId = -1,
                wallet
            };

            return await GetList(GET_CHARACTERS, param);
        }

        public virtual async Task UpdateAsync(IEnumerable<Character> characters)
        {
            var param = new
            {
                characters = characters.ToDataTable()
            };

            await Execute(UPDATE_CHARACTERS, param);
        }
    }
}
