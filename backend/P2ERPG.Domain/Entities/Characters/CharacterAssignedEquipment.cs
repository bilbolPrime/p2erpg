namespace BilbolStack.Boonamai.P2ERPG.Domain.Entities.Characters
{
    public class CharacterAssignedEquipment
    {
        public int CharacterId { get; set; }
        public int? WeaponId { get; set; }
        public int? ArmorId { get; set; }
        public int? ShieldId { get; set; }
    }
}
