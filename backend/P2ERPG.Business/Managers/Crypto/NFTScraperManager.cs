using BilbolStack.Boonamai.P2ERPG.Business.Managers.Configuration;
using BilbolStack.Boonamai.P2ERPG.Business.Records.Wallets;
using BilbolStack.Boonamai.P2ERPG.Crypto.NFTs;
using System.Transactions;
using System;
using BilbolStack.Boonamai.P2ERPG.Business.Records.Characters;
using BilbolStack.Boonamai.P2ERPG.Common.Enumeration;
using BilbolStack.Boonamai.P2ERPG.Business.Managers.Characters;
using BilbolStack.Boonamai.P2ERPG.Business.Records.Equipment;
using BilbolStack.Boonamai.P2ERPG.Business.Managers.Equipment.Armors;
using BilbolStack.Boonamai.P2ERPG.Business.Managers.Equipment.Shields;
using BilbolStack.Boonamai.P2ERPG.Business.Managers.Equipment.Weapons;

namespace BilbolStack.Boonamai.P2ERPG.Business.Managers.Crypto
{
    public class NFTScraperManager : INFTScraperManager
    {
        private const string NFT_SYNC_BLOCK_NUMBER = "NFTSyncBlockNumber";
        private readonly INFTContractScraper _nFTContractScraper;
        private readonly IConfigurationManager _configurationManager;
        private readonly ICharactersManager _charactersManager;
        private readonly IArmorsManager _armorsManager;
        private readonly IShieldsManager _shieldsManager;
        private readonly IWeaponsManager _weaponsManager;
        public NFTScraperManager(INFTContractScraper nFTContractScraper, IConfigurationManager configurationManager, ICharactersManager charactersManager,
             IArmorsManager armorsManager, IShieldsManager shieldsManager, IWeaponsManager weaponsManager)
        {
            _nFTContractScraper = nFTContractScraper;
            _configurationManager = configurationManager;
            _charactersManager = charactersManager;
            _armorsManager = armorsManager;
            _weaponsManager = weaponsManager;
            _shieldsManager = shieldsManager;
        }


        public async Task Tick()
        {
            var lastBlockNumber = await _configurationManager.GetConfiguration(NFT_SYNC_BLOCK_NUMBER);
            ulong blockNumber = ulong.Parse(lastBlockNumber ?? "0");
            var results = await _nFTContractScraper.CheckChange(blockNumber);
            if (results.BlockNumber != 0)
            {
                using (var scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
                {
                    {
                        if (results.Characters.Any())
                        {
                            var characters = results.Characters.Select(i => new Character(0, i.MintId, i.Wallet, CharacterType.Other, 0, 0, 0, 0, 0, 0, 0, 0));
                            await _charactersManager.UpdateAsync(characters);
                        }

                        if (results.Armors.Any())
                        {
                            var armors = results.Armors.Select(i => new Armor(0, i.MintId, i.Wallet, ArmorType.BirthdaySuit, 0));
                            await _armorsManager.UpdateAsync(armors);
                        }

                        if (results.Shields.Any())
                        {
                            var shields = results.Shields.Select(i => new Shield(0, i.MintId, i.Wallet, ShieldType.None, 0));
                            await _shieldsManager.UpdateAsync(shields);
                        }

                        if (results.Weapons.Any())
                        {
                            var weapons = results.Weapons.Select(i => new Weapon(0, i.MintId, i.Wallet, WeaponType.Fists, 0));
                            await _weaponsManager.UpdateAsync(weapons);
                        }

                        await _configurationManager.UpdateConfiguration(NFT_SYNC_BLOCK_NUMBER, results.BlockNumber.ToString());
                        scope.Complete();
                    }
                }
            }
        }
    }
}
