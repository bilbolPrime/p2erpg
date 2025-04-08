namespace BilbolStack.Boonamai.P2ERPG.Crypto.Validator
{
    public interface IChainValidator
    {
        bool ValidateWallet(string address);
        bool ValidateSignature(string account, string message, string signature);
    }
}