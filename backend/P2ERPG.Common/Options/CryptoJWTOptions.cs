namespace BilbolStack.Boonamai.P2ERPG.Common.Options
{
    public class CryptoJWTOptions
    {
        public const string KEY = "CryptoJWT";
        public string Secret { get; set; }
        public string ChallengeMessage { get; set; }
    }
}
