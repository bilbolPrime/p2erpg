using System.Net;
using System.Security;

namespace BilbolStack.Boonamai.P2ERPG.Common.Extensions
{
    public static class SecureStringExtensions
    {
        public static string ExtractPassword(this SecureString source)
        {
            return new NetworkCredential(string.Empty, source).Password;
        }
    }
}
