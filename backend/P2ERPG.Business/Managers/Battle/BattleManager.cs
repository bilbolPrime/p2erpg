using BilbolStack.Boonamai.P2ERPG.Business.Records.Battle;
using BilbolStack.Boonamai.P2ERPG.Common.Enumeration;

namespace BilbolStack.Boonamai.P2ERPG.Business.Managers.Battle
{
    public class BattleManager : IBattleManager
    {
        public BattleManager() { }

        public virtual BattleResult Battle(BattlePvP battle)
        {
            var hpAttacker = battle.attacker.hp;
            var hpDefender = battle.defender.hp;

            var attackerSpeed = battle.attacker.speed * SpeedFactor(battle.attArmorType);
            var defenderSpeed = battle.defender.speed * SpeedFactor(battle.defArmorType);

            bool attackerWon = false;
            List<BattleRound> rounds = new List<BattleRound>();
            int round = 0;

            var rnd = new Random();
            while (round <= 50 && hpAttacker > 0 && hpDefender > 0)
            {
                var roll = rnd.Next(battle.attacker.speed + battle.defender.speed);

                if (roll < battle.defender.speed)
                {
                    var damage = (int)((0.1f + rnd.NextDouble()) * battle.defender.strength * DamageFactor(battle.defWeaponType, battle.attArmorType, battle.attShieldType));
                    hpAttacker -= damage;
                    rounds.Add(new BattleRound(false, damage, hpAttacker));
                }
                else
                {
                    var damage = (int)((0.1f + rnd.NextDouble()) * battle.attacker.strength * DamageFactor(battle.attWeaponType, battle.defArmorType, battle.defShieldType));
                    hpDefender -= damage;
                    rounds.Add(new BattleRound(true, damage, hpAttacker));
                }

                round++;
            }

            return new BattleResult(rounds, hpDefender <= 0);
        }

        private float SpeedFactor(ArmorType armorType)
        {
            if (armorType == ArmorType.Heavy)
                return 0.75f;

            return 1f;
        }

        private float DamageFactor(WeaponType weaponType, ArmorType armorType, ShieldType shieldType)
        {
            var toReturn = 1f;

            if (weaponType == WeaponType.Fists)
            {
                toReturn *= 0.5f;
            }

            if (armorType == ArmorType.BirthdaySuit)
            {
                toReturn *= 2f;
            }

            if (weaponType == WeaponType.Bow && shieldType == ShieldType.Large)
            {
                toReturn *= 0.5f;
            }

            if (weaponType == WeaponType.Bow && shieldType == ShieldType.Small)
            {
                toReturn *= 1.5f;
            }

            if (weaponType == WeaponType.TwoHandedMace || weaponType == WeaponType.TwoHandedSword)
            {
                toReturn *= 1.5f;
            }

            if (weaponType == WeaponType.Mace || weaponType == WeaponType.TwoHandedMace)
            {
                if (shieldType == ShieldType.Large)
                {
                    toReturn *= 1.5f;
                }
            }

            // TODO: fill this shit up

            return toReturn;
        }
    }
}
