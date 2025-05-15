using BilbolStack.Boonamai.P2ERPG.Business.Records.Battle;
using BilbolStack.Boonamai.P2ERPG.Common.Enumeration;

namespace BilbolStack.Boonamai.P2ERPG.Business.Managers.Battle
{
    public class BattleManager : IBattleManager
    {
        private readonly IPvETargetManager _pvETargetManager;
        public BattleManager(IPvETargetManager pvETargetManager) 
        {
            _pvETargetManager = pvETargetManager;
        }

        public virtual BattleResult Battle(BattlePvP battle)
        {
            var hpAttacker = battle.attacker.hp;
            var hpDefender = battle.defender.hp;

            var attackerSpeed = battle.attacker.speed * SpeedFactor(battle.attArmorType, battle.attacker.characterType);
            var defenderSpeed = battle.defender.speed * SpeedFactor(battle.defArmorType, battle.defender.characterType);

            var attackerDodgeChance = Math.Min(0.9f, DodgeChance(battle.attacker.agility, battle.defender.concentration, battle.attArmorType, battle.attacker.characterType));
            var defenderDodgeChance = Math.Min(0.9f, DodgeChance(battle.defender.agility, battle.attacker.concentration, battle.defArmorType, battle.defender.characterType));


            List<BattleRound> rounds = new List<BattleRound>();
            int round = 0;

            var rnd = new Random();
            while (round <= 50 && hpAttacker > 0 && hpDefender > 0)
            {
                var roll = rnd.Next(battle.attacker.speed + battle.defender.speed);

                if (roll < battle.defender.speed)
                {
                    var damage = (int)((0.1f + rnd.NextDouble()) * battle.defender.strength * DamageFactor(battle.defWeaponType, battle.attArmorType, battle.attShieldType, battle.defender.characterType));

                    roll = rnd.Next(100);
                    
                    if(roll < 100 * attackerDodgeChance)
                    {
                        damage = 0;
                        attackerDodgeChance *= 0.9f;
                    }

                    hpAttacker -= damage;
                    rounds.Add(new BattleRound(false, damage, hpAttacker));
                }
                else
                {
                    var damage = (int)((0.1f + rnd.NextDouble()) * battle.attacker.strength * DamageFactor(battle.attWeaponType, battle.defArmorType, battle.defShieldType, battle.attacker.characterType));

                    roll = rnd.Next(100);

                    if (roll < 100 * defenderDodgeChance)
                    {
                        damage = 0;
                        defenderDodgeChance *= 0.9f;
                    }

                    hpDefender -= damage;
                    rounds.Add(new BattleRound(true, damage, hpDefender));
                }

                round++;
            }

            return new BattleResult(rounds, hpDefender <= 0);
        }

        public virtual BattleResult Battle(BattlePvE battle)
        {
            var hpAttacker = battle.attacker.hp;
            var target = _pvETargetManager.GetTarget(battle.target);
            var hpTarget = target.hp;
            var targetArmor = _pvETargetManager.GetArmorType(battle.target);
            var targetShield = _pvETargetManager.GetShieldType(battle.target);
            var targetWeapon = _pvETargetManager.GetWeaponType(battle.target);

            var attackerSpeed = battle.attacker.speed * SpeedFactor(battle.attArmorType, battle.attacker.characterType);
            var targetSpeed = target.speed * 0.5f; // Target is slower

            var attackerDodgeChance = Math.Min(0.9f, DodgeChance(battle.attacker.agility, target.concentration, battle.attArmorType, battle.attacker.characterType));
            var targetDodgeChance = Math.Min(0.9f, DodgeChance(target.agility, battle.attacker.concentration, targetArmor, target.characterType) * 0.5f); // Target has lower dodge chance

            List<BattleRound> rounds = new List<BattleRound>();
            int round = 0;

            var rnd = new Random();
            while (round <= 50 && hpAttacker > 0 && hpTarget > 0)
            {
                var roll = rnd.Next((int)(battle.attacker.speed + targetSpeed));

                if (roll < targetSpeed)
                {
                    var damage = (int)((0.1f + rnd.NextDouble()) * target.strength * 0.5f); // Target deals half damage
                    roll = rnd.Next(100);
                    
                    if(roll < 100 * attackerDodgeChance)
                    {
                        damage = 0;
                        attackerDodgeChance *= 0.9f;
                    }

                    hpAttacker -= damage;
                    rounds.Add(new BattleRound(false, damage, hpAttacker));
                }
                else
                {
                    var damage = (int)((0.1f + rnd.NextDouble()) * battle.attacker.strength * DamageFactor(battle.attWeaponType, targetArmor, targetShield, battle.attacker.characterType));
                    roll = rnd.Next(100);

                    if (roll < 100 * targetDodgeChance)
                    {
                        damage = 0;
                        targetDodgeChance *= 0.9f;
                    }

                    hpTarget -= damage;
                    rounds.Add(new BattleRound(true, damage, hpTarget));
                }

                round++;
            }

            return new BattleResult(rounds, hpTarget <= 0);
        }

        private float DodgeChance(int agility, int concentration, ArmorType armorType, CharacterType characterType)
        {
            var toReturn = (1f * agility) / (3f + concentration);

            if (armorType == ArmorType.BirthdaySuit)
            {
                toReturn *= 1.2f;
            }

            if (armorType == ArmorType.Light)
            {
                toReturn *= 1.1f;
            }

            if (armorType == ArmorType.Heavy)
            {
                toReturn *= 0.9f;
            }

            if(characterType == CharacterType.Elf)
            {
                toReturn *= 1.25f;
            }

            if(characterType == CharacterType.Skeleton)
            {
                toReturn *= 1.1f;
            }

            if (characterType == CharacterType.Orc)
            {
                toReturn *= 0.75f;
            }

            return toReturn;
        }

        private float SpeedFactor(ArmorType armorType, CharacterType characterType)
        {
            if (armorType == ArmorType.Heavy && characterType == CharacterType.Elf)
                return 0.6f;

            if (armorType == ArmorType.Heavy && characterType == CharacterType.Orc)
                return 0.85f;

            if (armorType == ArmorType.Heavy)
                return 0.75f;

            return 1f;
        }

        private float DamageFactor(WeaponType weaponType, ArmorType armorType, ShieldType shieldType, CharacterType characterType)
        {
            var toReturn = 1f;

            if (armorType == ArmorType.BirthdaySuit)
            {
                toReturn *= 2f;
            }

            if (weaponType == WeaponType.Fists)
            {
                toReturn *= 0.5f;

                if (characterType == CharacterType.Orc)
                {
                    toReturn *= 1.5f;
                }
            }

            if (weaponType == WeaponType.Bow)
            {
                if (shieldType == ShieldType.Large)
                {
                    toReturn *= 0.5f;
                }
                if (shieldType == ShieldType.Small)
                {
                    toReturn *= 1.5f;
                }
                if (characterType == CharacterType.Elf)
                {
                    toReturn *= 1.5f;
                }
                if (characterType == CharacterType.Orc)
                {
                    toReturn *= 0.5f;
                }
                if (armorType == ArmorType.Light)
                {
                    toReturn *= 2f;
                }
                if (armorType == ArmorType.Heavy)
                {
                    toReturn *= 0.5f;
                }
            }

            if (weaponType == WeaponType.Mace && characterType == CharacterType.Skeleton)
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

            if (weaponType == WeaponType.TwoHandedMace || weaponType == WeaponType.TwoHandedSword)
            {
                if (characterType == CharacterType.Orc)
                {
                    toReturn *= 1.5f;
                }

                if (armorType == ArmorType.Light)
                {
                    toReturn *= 1.2f;
                }

                if (armorType == ArmorType.Heavy)
                {
                    toReturn *= 0.8f;
                }
            }

            return toReturn;
        }
    }
}
