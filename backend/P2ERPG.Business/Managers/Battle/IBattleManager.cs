using BilbolStack.Boonamai.P2ERPG.Business.Records.Battle;

namespace BilbolStack.Boonamai.P2ERPG.Business.Managers.Battle
{
    public interface IBattleManager
    {
        BattleResult Battle(BattlePvP battle);
    }
}