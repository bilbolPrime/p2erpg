using BilbolStack.Boonamai.P2ERPG.Common.Options;
using BilbolStack.Boonamai.P2ERPG.Domain.Entities.Characters;
using Microsoft.Extensions.Options;

namespace BilbolStack.Boonamai.P2ERPG.Domain.Repositories.Characters
{
    public class CharactersRepository : BaseRepository<Character>, ICharactersRepository
    {
        private const string GET_CHARACTERS = "";
        private const string GET_CHARACTER = "";
        private const string UPDATE_CHARACTER = "";

        public CharactersRepository(IOptions<DBSettings> dbSettings) : base(dbSettings)
        {

        }

        public virtual async Task UpdateAsync(Character character)
        {
            var param = new
            {
                character.Id,
                character.Strength,
                character.Concentration,
                character.Endurance,
                character.Agility,
                character.HP,
                character.Speed,
                character.Experience,
                character.Level
            };

            await Execute(UPDATE_CHARACTER, param);
        }

        public virtual async Task<Character> GetAsync(int id, long mintId)
        {
            var param = new
            {
                id,
                mintId
            };

            return (await GetList(GET_CHARACTER, param)).FirstOrDefault();
        }

        public virtual async Task<IEnumerable<Character>> GetAsync(string wallet)
        {
            var param = new
            {
                wallet
            };

            return await GetList(GET_CHARACTERS, param);
        }

        public virtual async Task UpdateAsync(IEnumerable<Character> characters)
        {
            throw new NotImplementedException();
        }
    }
}
