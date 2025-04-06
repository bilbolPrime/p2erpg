using BilbolStack.Boonamai.P2ERPG.Common.Options;
using BilbolStack.Boonamai.P2ERPG.Domain.Entities.Characters;
using Microsoft.Extensions.Options;
using MoreLinq;

namespace BilbolStack.Boonamai.P2ERPG.Domain.Repositories.Characters
{
    public class CharacterAssignedEquipmentRepository : BaseRepository<CharacterAssignedEquipment>, ICharacterAssignedEquipmentRepository
    {
        private const string GET = "[P2ERPG].[equipment_get]";
        private const string UPDATE = "[P2ERPG].[equipment_update]";

        public CharacterAssignedEquipmentRepository(IOptions<DBSettings> dbSettings) : base(dbSettings)
        {

        }

        public virtual async Task UpdateAsync(CharacterAssignedEquipment characterAssignedEquipment)
        {
            var param = new
            {
                characterId = characterAssignedEquipment.CharacterId,
                weaponId = characterAssignedEquipment.WeaponId,
                armorId = characterAssignedEquipment.ArmorId,
                shieldId = characterAssignedEquipment.ShieldId
            };

            await Execute(UPDATE, param);
        }

        public virtual async Task<CharacterAssignedEquipment> GetAsync(int characterId)
        {
            var param = new
            {
                characterId
            };

            return (await GetList(GET, param)).FirstOrDefault();
        }
    }
}
