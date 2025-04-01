using AutoMapper;
using BilbolStack.Boonamai.P2ERPG.Domain.Repositories.Equipment;
using Entities = BilbolStack.Boonamai.P2ERPG.Domain.Entities;
using BilbolStack.Boonamai.P2ERPG.Business.Records.Equipment;

namespace BilbolStack.Boonamai.P2ERPG.Business.Managers.Armors
{
    public class ArmorsManager : IArmorsManager
    {
        private readonly IArmorsRepository _armorsRepository;
        private readonly IMapper _mapper;
        public ArmorsManager(IMapper mapper, IArmorsRepository armorsRepository)
        {
            _armorsRepository = armorsRepository;
            _mapper = mapper;
        }

        public async Task<Armor> GetAsync(int id, long mintId)
        {
            var data = await _armorsRepository.GetAsync(id, mintId);
            return _mapper.Map<Armor>(data);
        }

        public async Task<IEnumerable<Armor>> GetAsync(string wallet)
        {
            var data = await _armorsRepository.GetAsync(wallet);
            return _mapper.Map<IEnumerable<Armor>>(data);
        }

        public async Task UpdateAsync(Armor armor)
        {
            var mappedData = _mapper.Map<Entities.Equipment.Armor>(armor);
            await _armorsRepository.UpdateAsync(mappedData);
        }

        public async Task UpdateAsync(IEnumerable<Armor> armors)
        {
            var mappedData = _mapper.Map<IEnumerable<Entities.Equipment.Armor>>(armors);
            await _armorsRepository.UpdateAsync(mappedData);
        }
    }
}
