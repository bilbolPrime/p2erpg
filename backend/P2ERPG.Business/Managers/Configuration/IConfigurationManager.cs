namespace BilbolStack.Boonamai.P2ERPG.Business.Managers.Configuration
{
    public interface IConfigurationManager
    {
        Task<string> GetConfiguration(string configurationName);
        Task UpdateConfiguration(string configurationName, string configurationValue);
    }
}