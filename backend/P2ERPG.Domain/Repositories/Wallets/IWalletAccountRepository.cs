using BilbolStack.Boonamai.P2ERPG.Domain.Entities.Wallets;

namespace BilbolStack.Boonamai.P2ERPG.Domain.Repositories.Wallets
{
    public interface IWalletAccountRepository
    {
        Task CreateAsync(string wallet);
        Task<WalletAccount> GetAsync(int walletId, string wallet);
        Task SignAsync(WalletAccount walletAccount);
    }
}