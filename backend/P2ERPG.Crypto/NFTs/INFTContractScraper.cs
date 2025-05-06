using BilbolStack.P2ERPG.P2ERPG.Crypto.NFTs;

namespace BilbolStack.Boonamai.P2ERPG.Crypto.NFTs
{
    public interface INFTContractScraper
    {
        Task<NFTScrapeResult> CheckChange(ulong blockNumber);
    }
}
