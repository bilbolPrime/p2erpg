using BilbolStack.Boonamai.P2ERPG.Common.Options;
using BilbolStack.Boonamai.P2ERPG.Domain.Entities;
using BilbolStack.Boonamai.P2ERPG.Domain.Entities.Characters;
using Microsoft.Extensions.Options;

namespace BilbolStack.Boonamai.P2ERPG.Domain.Repositories.Characters
{
    public class CharactersMockRepository : CharactersRepository
    {
        private const string GET_CHARACTERS = "";
        private const string GET_CHARACTER = "";
        private const string UPDATE_CHARACTER = "";

        public CharactersMockRepository(IOptions<DBSettings> dbSettings) : base(dbSettings)
        {

        }

        public override async Task UpdateAsync(Character character)
        {
            await Task.CompletedTask;
        }

        public override async Task<Character> GetAsync(int characterId, long mintId)
        {
            return new Character() { CharacterId = characterId, MintId = mintId, Agility = 1, Concentration = 2, Endurance = 5, HP = 5, Speed = 2, Strength = 3, CharacterType = characterId % 3, Wallet = mintId.ToString()};
        }

        public override async Task<IEnumerable<Character>> GetAsync(string wallet)
        {
            return new List<Character>()
            {
                new Character() { Agility = 1, Concentration = 2, Endurance = 5, HP = 5, Speed = 2, Strength = 3, CharacterType = 0, Wallet = wallet, Level = 1 },
                new Character() { Agility = 2, Concentration = 5, Endurance = 15, HP = 35, Speed = 42, Strength = 13, CharacterType = 1, Wallet = wallet, Level = 2 },
                new Character() { Agility = 2, Concentration = 5, Endurance = 15, HP = 35, Speed = 42, Strength = 13, CharacterType = 2, Wallet = wallet, Level = 3 }
            };
        }

        public override async Task UpdateAsync(IEnumerable<Character> characters)
        {
            await Task.CompletedTask;
        }

        public override async Task UpdateAsync(IEnumerable<NFTOwnership> nFTOwnerships)
        {
            await Task.CompletedTask;
        }
    }
}
