using AutoMapper;
using BilbolStack.Boonamai.P2ERPG.Domain.Repositories.Equipment;
using Entities = BilbolStack.Boonamai.P2ERPG.Domain.Entities;
using BilbolStack.Boonamai.P2ERPG.Business.Records.Equipment;

namespace BilbolStack.Boonamai.P2ERPG.Business.Managers.Weapons
{
    public class WeaponsManager : IWeaponsManager
    {
        private readonly IWeaponsRepository _weaponsRepository;
        private readonly IMapper _mapper;
        public WeaponsManager(IMapper mapper, IWeaponsRepository weaponsRepository)
        {
            _weaponsRepository = weaponsRepository;
            _mapper = mapper;
        }

        public async Task<Weapon> GetAsync(int id, long mintId)
        {
            var data = await _weaponsRepository.GetAsync(id, mintId);
            return _mapper.Map<Weapon>(data);
        }

        public async Task<IEnumerable<Weapon>> GetAsync(string wallet)
        {
            var data = await _weaponsRepository.GetAsync(wallet);
            return _mapper.Map<IEnumerable<Weapon>>(data);
        }

        public async Task UpdateAsync(Weapon weapon)
        {
            var mappedData = _mapper.Map<Entities.Equipment.Weapon>(weapon);
            await _weaponsRepository.UpdateAsync(mappedData);
        }

        public async Task UpdateAsync(IEnumerable<Weapon> weapons)
        {
            var mappedData = _mapper.Map<Entities.Equipment.Weapon>(weapons);
            await _weaponsRepository.UpdateAsync(mappedData);
        }
    }
}
