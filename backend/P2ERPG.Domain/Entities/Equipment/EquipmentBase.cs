namespace BilbolStack.Boonamai.P2ERPG.Domain.Entities.Equipment
{
    public class EquipmentBase
    {
        public int Id { get; set; }
        public long MintId { get; set; }
        public string Wallet { get; set; }
        public int EquipmentType { get; set; }
        public int Roll { get; set; }
    }
}
