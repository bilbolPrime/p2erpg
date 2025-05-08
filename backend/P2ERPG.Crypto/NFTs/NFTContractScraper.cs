using BilbolStack.Boonamai.P2ERPG.Common.Constants;
using BilbolStack.Boonamai.P2ERPG.Common.Options;
using BilbolStack.P2ERPG.P2ERPG.Crypto.NFTs;
using Microsoft.Extensions.Options;
using Nethereum.BlockchainProcessing.BlockStorage.Entities.Mapping;
using Nethereum.Hex.HexTypes;
using Nethereum.RPC.Eth.DTOs;
using Nethereum.Web3;
using Nethereum.Web3.Accounts;

namespace BilbolStack.Boonamai.P2ERPG.Crypto.NFTs
{
    public class NFTContractScraper : INFTContractScraper
    {
        protected Web3 _web3;
        protected string _charactersContractAddress;
        protected string _armorsContractAddress;
        protected string _shieldsContractAddress;
        protected string _weaponsContractAddress;
        protected Account _account;


        public NFTContractScraper(IOptions<ChainSettings> chainSettings)
        {
            _account = new Account(chainSettings.Value.AccountPrivateKey, chainSettings.Value.ChainId);
            _web3 = new Web3(_account, chainSettings.Value.RpcUrl);
            _web3.TransactionManager.UseLegacyAsDefault = true;
            _charactersContractAddress = chainSettings.Value.CharactersNFTAddress;
            _armorsContractAddress = chainSettings.Value.ArmorsNFTAddress;
            _shieldsContractAddress = chainSettings.Value.ShieldsNFTAddress;
            _weaponsContractAddress = chainSettings.Value.WeaponsNFTAddress;
        }

        public async Task<NFTScrapeResult> CheckChange(ulong startBlock)
        {
            var latestBlockNumber = await _web3.Eth.Blocks.GetBlockNumber.SendRequestAsync();
            var endBlock = Math.Min(startBlock  + 255,(ulong) latestBlockNumber.ToLong());

            var result = new NFTScrapeResult();

            if (startBlock > (ulong) latestBlockNumber.Value.ToHexBigInteger().ToLong())
            {
                return result;
            }


            {
                var transferEvent = _web3.Eth.GetEvent<TransferEventDTO>(_charactersContractAddress);
                var filterInput = transferEvent.CreateFilterInput(new BlockParameter(startBlock.ToHexBigInteger()), new BlockParameter(((ulong)endBlock).ToHexBigInteger()));
                var transfers = await transferEvent.GetAllChangesAsync(filterInput);
                foreach (var transfer in transfers)
                {
                    result.AddCharacter(transfer.Event.Value.ToHexBigInteger().ToLong(), transfer.Event.To, transfer.Event.From == Addresses.EVMZero);
                }
            }

            {
                var transferEvent = _web3.Eth.GetEvent<TransferEventDTO>(_weaponsContractAddress);
                var filterInput = transferEvent.CreateFilterInput(new BlockParameter(startBlock.ToHexBigInteger()), new BlockParameter(((ulong)endBlock).ToHexBigInteger()));
                var transfers = await transferEvent.GetAllChangesAsync(filterInput);
                foreach (var transfer in transfers)
                {
                    result.AddWeapon(transfer.Event.Value.ToHexBigInteger().ToLong(), transfer.Event.To, transfer.Event.From == Addresses.EVMZero);
                }
            }

            {
                var transferEvent = _web3.Eth.GetEvent<TransferEventDTO>(_armorsContractAddress);
                var filterInput = transferEvent.CreateFilterInput(new BlockParameter(startBlock.ToHexBigInteger()), new BlockParameter(((ulong)endBlock).ToHexBigInteger()));
                var transfers = await transferEvent.GetAllChangesAsync(filterInput);
                foreach (var transfer in transfers)
                {
                    result.AddArmor(transfer.Event.Value.ToHexBigInteger().ToLong(), transfer.Event.To, transfer.Event.From == Addresses.EVMZero);
                }
            }

            {
                var transferEvent = _web3.Eth.GetEvent<TransferEventDTO>(_shieldsContractAddress);
                var filterInput = transferEvent.CreateFilterInput(new BlockParameter(startBlock.ToHexBigInteger()), new BlockParameter(((ulong)endBlock).ToHexBigInteger()));
                var transfers = await transferEvent.GetAllChangesAsync(filterInput);
                foreach (var transfer in transfers)
                {
                    result.AddShield(transfer.Event.Value.ToHexBigInteger().ToLong(), transfer.Event.To, transfer.Event.From == Addresses.EVMZero);
                }
            }

            result.BlockNumber = (ulong) endBlock + 1;
            return result;
        }
    }
}
