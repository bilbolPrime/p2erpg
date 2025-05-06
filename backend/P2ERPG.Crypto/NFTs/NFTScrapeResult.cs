namespace BilbolStack.P2ERPG.P2ERPG.Crypto.NFTs
{
    public class NFTScrapeResult
    {
        public NFTScrapeResult()
        {
            Changes = new List<OwnershipChange>();
        }

        public ulong BlockNumber { get; set; }
        public List<OwnershipChange> Changes {get;set;}

        public void Add(long mintId, string wallet, bool isMint)
        {
            Changes.Add(new OwnershipChange() { MintId = mintId, Wallet = wallet, IsMint = isMint });
        }
    }

    public class OwnershipChange
    {
        public long MintId { get; set; }
        public string Wallet { get; set; }
        public bool IsMint { get; set; }
    }
}
