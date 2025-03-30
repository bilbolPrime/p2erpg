using BilbolStack.Boonamai.P2ERPG.Business.Records.Characters;

namespace BilbolStack.Boonamai.P2ERPG.Business.Managers.Characters
{
    public interface ICharactersManager
    {
        Task<Character> GetAsync(int id, long mintId);
        Task<IEnumerable<Character>> GetAsync(string wallet);
        Task UpdateAsync(Character character);
        Task UpdateAsync(IEnumerable<Character> characters);
    }
}