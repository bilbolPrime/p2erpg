using BilbolStack.Boonamai.P2ERPG.Business.Records.Characters;

namespace BilbolStack.Boonamai.P2ERPG.Business.Records.Battle
{
    public record BattleResult(List<BattleRound> rounds, bool attackerWon);

    public record BattleRound(bool isAttacker, int damage, int hpLeft);
}
