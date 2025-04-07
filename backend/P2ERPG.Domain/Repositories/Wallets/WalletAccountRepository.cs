using BilbolStack.Boonamai.P2ERPG.Common.Options;
using BilbolStack.Boonamai.P2ERPG.Domain.Entities.Wallets;
using Microsoft.Extensions.Options;
using MoreLinq;

namespace BilbolStack.Boonamai.P2ERPG.Domain.Repositories.Wallets
{
    public class WalletAccountRepository : BaseRepository<WalletAccount>, IWalletAccountRepository
    {
        private const string GET_WALLET = "[P2ERPG].[wallets_get]";
        private const string SIGN_WALLET = "[P2ERPG].[wallets_sign]";
        private const string CREATE_WALLET = "[P2ERPG].[wallets_create]";

        public WalletAccountRepository(IOptions<DBSettings> dbSettings) : base(dbSettings)
        {

        }

        public virtual async Task SignAsync(WalletAccount walletAccount)
        {
            var param = new
            {
                walletId = walletAccount.WalletId,
                signedNonce = walletAccount.ActiveNonce
            };

            await Execute(SIGN_WALLET, param);
        }

        public virtual async Task<WalletAccount> GetAsync(int walletId, string wallet)
        {
            var param = new
            {
                walletId,
                wallet,
            };

            return (await GetList(GET_WALLET, param)).FirstOrDefault();
        }

        public virtual async Task CreateAsync(string wallet)
        {
            var param = new
            {
                wallet
            };

            await Execute(CREATE_WALLET, param);
        }
    }
}
