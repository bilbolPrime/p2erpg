namespace BilbolStack.P2ERPG.P2ERPG.Crypto.NFTs
{
    public class NFTScrapeResult
    {
        public NFTScrapeResult()
        {
            Characters = new List<OwnershipChange>();
            Armors = new List<OwnershipChange>();
            Weapons = new List<OwnershipChange>();
            Shields = new List<OwnershipChange>();
        }

        public ulong BlockNumber { get; set; }
        public List<OwnershipChange> Characters {get;set;}
        public List<OwnershipChange> Shields { get; set; }
        public List<OwnershipChange> Armors { get; set; }
        public List<OwnershipChange> Weapons { get; set; }

        public void AddCharacter(long mintId, string wallet, bool isMint)
        {
            Characters.Add(new OwnershipChange() { MintId = mintId, Wallet = wallet, IsMint = isMint });
        }

        public void AddWeapon(long mintId, string wallet, bool isMint)
        {
            Weapons.Add(new OwnershipChange() { MintId = mintId, Wallet = wallet, IsMint = isMint });
        }

        public void AddShield(long mintId, string wallet, bool isMint)
        {
            Shields.Add(new OwnershipChange() { MintId = mintId, Wallet = wallet, IsMint = isMint });
        }

        public void AddArmor(long mintId, string wallet, bool isMint)
        {
            Armors.Add(new OwnershipChange() { MintId = mintId, Wallet = wallet, IsMint = isMint });
        }
    }

    public class OwnershipChange
    {
        public long MintId { get; set; }
        public string Wallet { get; set; }
        public bool IsMint { get; set; }
    }
}
