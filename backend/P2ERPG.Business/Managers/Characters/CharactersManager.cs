using AutoMapper;
using BilbolStack.Boonamai.P2ERPG.Business.Records;
using BilbolStack.Boonamai.P2ERPG.Business.Records.Characters;
using BilbolStack.Boonamai.P2ERPG.Domain.Repositories.Characters;
using Entities = BilbolStack.Boonamai.P2ERPG.Domain.Entities;

namespace BilbolStack.Boonamai.P2ERPG.Business.Managers.Characters
{
    public class CharactersManager : ICharactersManager
    {
        private readonly ICharactersRepository _charactersRepository;
        private readonly IMapper _mapper;
        public CharactersManager(IMapper mapper, ICharactersRepository charactersRepository)
        {
            _charactersRepository = charactersRepository;
            _mapper = mapper;
        }

        public async Task<Character> GetAsync(int id, long mintId)
        {
            var data = await _charactersRepository.GetAsync(id, mintId);
            return _mapper.Map<Character>(data);
        }

        public async Task<IEnumerable<Character>> GetAsync(string wallet)
        {
            var data = await _charactersRepository.GetAsync(wallet);
            return _mapper.Map<IEnumerable<Character>>(data);
        }

        public async Task UpdateAsync(Character character)
        {
            var mappedData = _mapper.Map<Entities.Characters.Character>(character);
            await _charactersRepository.UpdateAsync(mappedData);
        }

        public async Task UpdateAsync(IEnumerable<Character> characters)
        {
            var mappedData = _mapper.Map<IEnumerable<Entities.Characters.Character>>(characters);
            await _charactersRepository.UpdateAsync(mappedData);
        }

        public async Task UpdateAsync(IEnumerable<NFTOwnership> nFTOwnerships)
        {
            var mappedData = _mapper.Map<IEnumerable<Entities.NFTOwnership>>(nFTOwnerships);
            await _charactersRepository.UpdateAsync(mappedData);
        }
    }
}
