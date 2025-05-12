using BilbolStack.Boonamai.P2ERPG.Business.Records;
using BilbolStack.Boonamai.P2ERPG.Business.Records.Equipment;

namespace BilbolStack.Boonamai.P2ERPG.Business.Managers.Equipment
{
    public interface IEquipmentsManager
    {
        Task<Armor> GetArmorAsync(int armorId, long mintId);
        Task<IEnumerable<Armor>> GetArmorsAsync(string wallet);
        Task<Shield> GetShieldAsync(int shieldId, long mintId);
        Task<IEnumerable<Shield>> GetShieldsAsync(string wallet);
        Task<Weapon> GetWeaponAsync(int weaponId, long mintId);
        Task<IEnumerable<Weapon>> GetWeaponsAsync(string wallet);
        Task UpdateAsync(Armor armor);
        Task UpdateAsync(IEnumerable<Armor> armors);
        Task UpdateAsync(IEnumerable<Shield> shields);
        Task UpdateAsync(IEnumerable<Weapon> weapons);
        Task UpdateAsync(Shield shield);
        Task UpdateAsync(Weapon weapon);
        Task UpdateArmorsOwnershipAsync(IEnumerable<NFTOwnership> nFTOwnerships);
        Task UpdateWeaponsOwnershipAsync(IEnumerable<NFTOwnership> nFTOwnerships);
        Task UpdateShieldOwnershipAsync(IEnumerable<NFTOwnership> nFTOwnerships);
    }
}