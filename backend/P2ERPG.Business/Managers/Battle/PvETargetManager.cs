using BilbolStack.Boonamai.P2ERPG.Business.Records.Characters;
using BilbolStack.Boonamai.P2ERPG.Common.Enumeration;

namespace BilbolStack.Boonamai.P2ERPG.Business.Managers.Battle
{
    public static class PvETargetManager
    {
        public static Character GetTarget(PvETarget target)
        {
            return target switch
            {
                PvETarget.WoodenDummy => new Character(1, 1, "Wooden Dummy", CharacterType.WoodenDummy, 10, 0, 0, 0, 0, 0, 0, 0),
                PvETarget.Chicken => new Character(1, 1, "Chicken", CharacterType.Chicken, 15, 2, 1, 0, 0, 0, 0, 0),
                PvETarget.Dogo => new Character(1, 1, "Dogo", CharacterType.Dogo, 20, 3, 2, 0, 0, 0, 0, 0),
                PvETarget.DaphneBlake => new Character(1, 1, "Daphne Blake", CharacterType.DaphneBlake, 25, 4, 3, 1, 1, 1, 0, 0),
                PvETarget.Thug => new Character(1, 1, "Thug", CharacterType.Thug, 30, 5, 4, 2, 2, 2, 0, 0),
                PvETarget.Sellsword => new Character(1, 1, "Sellsword", CharacterType.Sellsword, 35, 6, 5, 3, 3, 3, 0, 0),
                PvETarget.Uruk => new Character(1, 1, "Uruk", CharacterType.Uruk, 40, 7, 6, 4, 4, 4, 0, 0),
                PvETarget.Legolas => new Character(1, 1, "Legolas", CharacterType.Legolas, 45, 8, 7, 5, 5, 5, 0, 0),
                PvETarget.Batman => new Character(1, 1, "Batman", CharacterType.Batman, 50, 9, 8, 6, 6, 6, 0, 0),
                _ => throw new ArgumentException($"Unknown PvE target: {target}")
            };
        }
    }
} 