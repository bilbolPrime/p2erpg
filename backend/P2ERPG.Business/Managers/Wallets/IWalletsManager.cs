using BilbolStack.Boonamai.P2ERPG.Business.Records.Wallets;

namespace BilbolStack.Boonamai.P2ERPG.Business.Managers.Wallets
{
    public interface IWalletsManager
    {
        Task CreateAsync(string wallet);
        Task<Wallet> GetAsync(int walletId, string wallet);
        Task SignAsync(Wallet wallet);
    }
}