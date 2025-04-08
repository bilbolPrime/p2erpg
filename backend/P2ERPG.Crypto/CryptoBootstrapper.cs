using BilbolStack.Boonamai.P2ERPG.Crypto.Validator;
using Microsoft.Extensions.DependencyInjection;

namespace BilbolStack.Boonamai.P2ERPG.Crypto.Crypto
{
    public static class CryptoBootstrapper
    {
        public static void BootstrapCrypto(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddSingleton<IChainValidator, ChainValidator>();
        }
    }
}
