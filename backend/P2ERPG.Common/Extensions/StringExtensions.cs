using System.Net;
using System.Security;

namespace BilbolStack.Boonamai.P2ERPG.Common.Extensions
{
    public static class StringExtensions
    {
        public static SecureString ToSecureString(this string source)
        {
            return new NetworkCredential(string.Empty, source).SecurePassword;
        }
    }
}
