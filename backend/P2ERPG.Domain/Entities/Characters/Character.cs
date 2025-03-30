namespace BilbolStack.Boonamai.P2ERPG.Domain.Entities.Characters
{
    public class Character
    {
        public int Id { get; set; }
        public long MintId { get; set; }
        public string? Wallet { get; set; }
        public int Type { get; set; }
        public int HP { get; set; }
        public int Strength { get; set; }
        public int Speed { get; set; }
        public int Agility { get; set; }
        public int Concentration { get; set; }
        public int Endurance { get; set; }
        public int Experience { get; set; }
        public int Level { get; set; }
    }
}
