using AutoMapper;
using BilbolStack.Boonamai.P2ERPG.Business.Records.Wallets;
using BilbolStack.Boonamai.P2ERPG.Domain.Repositories.Wallets;
using Entities = BilbolStack.Boonamai.P2ERPG.Domain.Entities;

namespace BilbolStack.Boonamai.P2ERPG.Business.Managers.Wallets
{
    public class WalletsManager : IWalletsManager
    {
        private readonly IWalletAccountRepository _walletAccountRepository;
        private readonly IMapper _mapper;
        public WalletsManager(IMapper mapper, IWalletAccountRepository walletAccountRepository)
        {
            _walletAccountRepository = walletAccountRepository;
            _mapper = mapper;
        }

        public async Task<Wallet> GetAsync(int walletId, string wallet)
        {
            var data = await _walletAccountRepository.GetAsync(walletId, wallet);
            return _mapper.Map<Wallet>(data);
        }

        public async Task SignAsync(Wallet wallet)
        {
            var mappedData = _mapper.Map<Entities.Wallets.WalletAccount>(wallet);
            await _walletAccountRepository.SignAsync(mappedData);
        }

        public async Task CreateAsync(string wallet)
        {
            await _walletAccountRepository.CreateAsync(wallet);
        }
    }
}
