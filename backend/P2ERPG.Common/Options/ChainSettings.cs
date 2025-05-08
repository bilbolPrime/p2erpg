namespace BilbolStack.Boonamai.P2ERPG.Common.Options
{
    public class ChainSettings
    {
        public const string KEY = "ChainInfo";
        public string AccountPrivateKey { get; set; }
        public long ChainId { get; set; }
        public string RpcUrl { get; set; }
        public string CharactersNFTAddress { get; set; }
        public string WeaponsNFTAddress { get; set; }
        public string ArmorsNFTAddress { get; set; }
        public string ShieldsNFTAddress { get; set; }
    }
}
