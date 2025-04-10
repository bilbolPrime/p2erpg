using BilbolStack.Boonamai.P2ERPG.Common.Enumeration;

namespace BilbolStack.Boonamai.P2ERPG.Business.Records.Equipment
{
    public class Equipment
    {
        public int Id { get; init; }
        public EquipmentType Type { get; init; }
        public EquipmentSlot Slot { get; init; }
        public int StrengthBonus { get; init; }
        public int DefenseBonus { get; init; }
        public int SpeedBonus { get; init; }
        public int AgilityBonus { get; init; }
        public int MagicBonus { get; init; }
        public int ResistanceBonus { get; init; }

        public Equipment(int id, EquipmentType type, EquipmentSlot slot, int strengthBonus, int defenseBonus, int speedBonus, int agilityBonus, int magicBonus, int resistanceBonus)
        {
            Id = id;
            Type = type;
            Slot = slot;
            StrengthBonus = strengthBonus;
            DefenseBonus = defenseBonus;
            SpeedBonus = speedBonus;
            AgilityBonus = agilityBonus;
            MagicBonus = magicBonus;
            ResistanceBonus = resistanceBonus;
        }
    }
} 