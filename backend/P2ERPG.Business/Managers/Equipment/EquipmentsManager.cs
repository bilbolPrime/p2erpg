using AutoMapper;
using BilbolStack.Boonamai.P2ERPG.Business.Records.Equipment;
using BilbolStack.Boonamai.P2ERPG.Business.Managers.Equipment.Armors;
using BilbolStack.Boonamai.P2ERPG.Business.Managers.Equipment.Weapons;
using BilbolStack.Boonamai.P2ERPG.Business.Managers.Equipment.Shields;
using BilbolStack.Boonamai.P2ERPG.Business.Records;

namespace BilbolStack.Boonamai.P2ERPG.Business.Managers.Equipment
{
    public class EquipmentsManager : IEquipmentsManager
    {
        private readonly IArmorsManager _armorsManager;
        private readonly IWeaponsManager _weaponsManager;
        private readonly IShieldsManager _shieldsManager;
        private readonly IMapper _mapper;
        public EquipmentsManager(IMapper mapper, IArmorsManager armorsManager, IWeaponsManager weaponsManager, IShieldsManager shieldsManager)
        {
            _armorsManager = armorsManager;
            _weaponsManager = weaponsManager;
            _shieldsManager = shieldsManager;
            _mapper = mapper;
        }

        public async Task<Armor> GetArmorAsync(int armorId, long mintId)
        {
            return await _armorsManager.GetAsync(armorId, mintId);
        }

        public async Task<IEnumerable<Armor>> GetArmorsAsync(string wallet)
        {
            return await _armorsManager.GetAsync(wallet);
        }

        public async Task<Weapon> GetWeaponAsync(int weaponId, long mintId)
        {
            return await _weaponsManager.GetAsync(weaponId, mintId);
        }

        public async Task<IEnumerable<Weapon>> GetWeaponsAsync(string wallet)
        {
            return await _weaponsManager.GetAsync(wallet);
        }

        public async Task<Shield> GetShieldAsync(int shieldId, long mintId)
        {
            return await _shieldsManager.GetAsync(shieldId, mintId);
        }

        public async Task<IEnumerable<Shield>> GetShieldsAsync(string wallet)
        {
            return await _shieldsManager.GetAsync(wallet);
        }

        public async Task UpdateAsync(Armor armor)
        {
            await _armorsManager.UpdateAsync(armor);
        }

        public async Task UpdateAsync(IEnumerable<Armor> armors)
        {
            await _armorsManager.UpdateAsync(armors);
        }

        public async Task UpdateAsync(Weapon weapon)
        {
            await _weaponsManager.UpdateAsync(weapon);
        }

        public async Task UpdateAsync(IEnumerable<Weapon> weapons)
        {
            await _weaponsManager.UpdateAsync(weapons);
        }

        public async Task UpdateAsync(Shield shield)
        {
            await _shieldsManager.UpdateAsync(shield);
        }

        public async Task UpdateAsync(IEnumerable<Shield> shields)
        {
            await _shieldsManager.UpdateAsync(shields);
        }

        public async Task UpdateArmorsOwnershipAsync(IEnumerable<NFTOwnership> nFTOwnerships)
        {
            await _armorsManager.UpdateAsync(nFTOwnerships);
        }

        public async Task UpdateWeaponsOwnershipAsync(IEnumerable<NFTOwnership> nFTOwnerships)
        {
            await _weaponsManager.UpdateAsync(nFTOwnerships);
        }

        public async Task UpdateShieldOwnershipAsync(IEnumerable<NFTOwnership> nFTOwnerships)
        {
            await _shieldsManager.UpdateAsync(nFTOwnerships);
        }
    }
}
