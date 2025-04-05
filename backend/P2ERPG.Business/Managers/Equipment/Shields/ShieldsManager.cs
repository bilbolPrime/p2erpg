using AutoMapper;
using BilbolStack.Boonamai.P2ERPG.Domain.Repositories.Equipment;
using Entities = BilbolStack.Boonamai.P2ERPG.Domain.Entities;
using BilbolStack.Boonamai.P2ERPG.Business.Records.Equipment;

namespace BilbolStack.Boonamai.P2ERPG.Business.Managers.Equipment.Shields
{
    public class ShieldsManager : IShieldsManager
    {
        private readonly IShieldsRepository _shieldsRepository;
        private readonly IMapper _mapper;
        public ShieldsManager(IMapper mapper, IShieldsRepository shieldsRepository)
        {
            _shieldsRepository = shieldsRepository;
            _mapper = mapper;
        }

        public async Task<Shield> GetAsync(int id, long mintId)
        {
            var data = await _shieldsRepository.GetAsync(id, mintId);
            return _mapper.Map<Shield>(data);
        }

        public async Task<IEnumerable<Shield>> GetAsync(string wallet)
        {
            var data = await _shieldsRepository.GetAsync(wallet);
            return _mapper.Map<IEnumerable<Shield>>(data);
        }

        public async Task UpdateAsync(Shield shield)
        {
            var mappedData = _mapper.Map<Entities.Equipment.Shield>(shield);
            await _shieldsRepository.UpdateAsync(mappedData);
        }

        public async Task UpdateAsync(IEnumerable<Shield> shields)
        {
            var mappedData = _mapper.Map<Entities.Equipment.Shield>(shields);
            await _shieldsRepository.UpdateAsync(mappedData);
        }
    }
}
