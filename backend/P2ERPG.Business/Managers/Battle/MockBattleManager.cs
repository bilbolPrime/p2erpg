using BilbolStack.Boonamai.P2ERPG.Business.Records.Battle;
using BilbolStack.Boonamai.P2ERPG.Business.Records.Characters;
using BilbolStack.Boonamai.P2ERPG.Common.Enumeration;

namespace BilbolStack.Boonamai.P2ERPG.Business.Managers.Battle
{
    public class MockBattleManager : BattleManager
    {
        public MockBattleManager() : base() { }

        public override BattleResult Battle(BattlePvP battle)
        {
            Character attacker = new Character(1, 1, "", CharacterType.Human, 1000, 100, 5, 2, 3, 1, 1, 1);
            Character defender = new Character(1, 1, "", CharacterType.Human, 1000, 500, 5, 2, 3, 1, 1, 1);

            battle = new BattlePvP(attacker, WeaponType.Sword, ShieldType.None, ArmorType.Medium, defender, WeaponType.Fists, ShieldType.Large, ArmorType.Heavy);

            return base.Battle(battle);
        }
    }
}
