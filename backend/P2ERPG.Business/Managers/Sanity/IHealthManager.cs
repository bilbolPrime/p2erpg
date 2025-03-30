using BilbolStack.Boonamai.P2ERPG.Business.Records.Sanity;

namespace BilbolStack.Boonamai.P2ERPG.Business.Managers.Sanity
{
    public interface IHealthManager
    {
        Task<HealthCheck> Check();
    }
}