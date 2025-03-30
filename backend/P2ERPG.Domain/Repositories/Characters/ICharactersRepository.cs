using BilbolStack.Boonamai.P2ERPG.Domain.Entities.Characters;

namespace BilbolStack.Boonamai.P2ERPG.Domain.Repositories.Characters
{
    public interface ICharactersRepository
    {
        Task<Character> GetAsync(int id, long mintId);
        Task<IEnumerable<Character>> GetAsync(string wallet);
        Task UpdateAsync(IEnumerable<Character> characters);
        Task UpdateAsync(Character character);
    }
}