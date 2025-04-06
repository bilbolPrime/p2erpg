using AutoMapper;
using BilbolStack.Boonamai.P2ERPG.Business.Records.Characters;
using BilbolStack.Boonamai.P2ERPG.Domain.Repositories.Characters;
using Entities = BilbolStack.Boonamai.P2ERPG.Domain.Entities;

namespace BilbolStack.Boonamai.P2ERPG.Business.Managers.Characters
{
    public class CharacterEquipmentManager
    {
        private readonly ICharacterAssignedEquipmentRepository _characterAssignedEquipmentRepository;
        private readonly IMapper _mapper;
        public CharacterEquipmentManager(IMapper mapper, ICharacterAssignedEquipmentRepository characterAssignedEquipmentRepository)
        {
            _characterAssignedEquipmentRepository = characterAssignedEquipmentRepository;
            _mapper = mapper;
        }

        public async Task<CharacterAssignedEquipment> GetAsync(int characterId)
        {
            var data = await _characterAssignedEquipmentRepository.GetAsync(characterId);
            return _mapper.Map<CharacterAssignedEquipment>(data);
        }

        public async Task UpdateAsync(CharacterAssignedEquipment characterAssignedEquipment)
        {
            var mappedData = _mapper.Map<Entities.Characters.CharacterAssignedEquipment>(characterAssignedEquipment);
            await _characterAssignedEquipmentRepository.UpdateAsync(mappedData);
        }
    }
}
