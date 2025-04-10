using BilbolStack.Boonamai.P2ERPG.Business.Records.Characters;

namespace BilbolStack.Boonamai.P2ERPG.Business.Records.Battle
{
    public record BattleResult
    {
        public List<BattleRound> Rounds { get; init; }
        public bool AttackerWon { get; init; }

        public BattleResult(List<BattleRound> rounds, bool attackerWon)
        {
            Rounds = rounds;
            AttackerWon = attackerWon;
        }
    }

    public record BattleRound(bool isAttacker, int damage, int hpLeft);
}
