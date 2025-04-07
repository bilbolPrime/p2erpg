namespace BilbolStack.Boonamai.P2ERPG.Domain.Entities.Wallets
{
    public class WalletAccount
    {
        public int WalletId { get; set; }
        public string? Wallet { get; set; }
        public string? ActiveNonce { get; set; }
        public DateTime? LastSignIn { get; set; }
        public string? LastSignedNonce { get; set; }
    }
}
