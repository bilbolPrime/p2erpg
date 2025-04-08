
namespace BilbolStack.Boonamai.P2ERPG.Business.Managers.Security
{
    public interface ISecurityManager
    {
        Task AssertAccess(string wallet, string signature);
        Task<string> GetChallenge(string wallet);
        Task<string> SignIn(string wallet, string signature);
    }
}