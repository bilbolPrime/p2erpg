using Nethereum.Hex.HexConvertors.Extensions;
using Nethereum.Signer;
using Nethereum.Util;
using System.Text;

namespace BilbolStack.Boonamai.P2ERPG.Crypto.Validator
{
    public class ChainValidator : IChainValidator
    {
        public bool ValidateWallet(string address)
        {
            if (string.IsNullOrEmpty(address) || address.Length != 42)
            {
                return false;
            }

            return new AddressUtil().IsChecksumAddress(address);
        }

        public bool ValidateSignature(string account, string message, string signature)
        {
            var signer = new EthereumMessageSigner();
            var bytes = Encoding.UTF8.GetBytes(message);
            var hash = BitConverter.ToString(bytes).Replace("-", "");
            return account == signer.EcRecover(hash.HexToByteArray(), signature);
        }
    }
}
