import { PvETarget } from './PvETarget';
import { Character } from '../../Character/Character';
import { CharacterType } from '../../Character/CharacterType';
import { Equipment } from '../../Equipment/Equipment';
import { EquipmentType } from '../../Equipment/EquipmentType';
import { EquipmentSlot } from '../../Equipment/EquipmentSlot';
import { Stats } from '../../Stats/Stats';

export class PvETargetManager {
    public static getTarget(target: PvETarget): Character {
        switch (target) {
            case PvETarget.WoodenDummy:
                return new Character(
                    CharacterType.WoodenDummy,
                    new Stats(10, 0, 0, 0, 0, 0),
                    new Equipment(EquipmentType.WoodenDummy, EquipmentSlot.None)
                );
            case PvETarget.Chicken:
                return new Character(
                    CharacterType.Chicken,
                    new Stats(15, 2, 1, 0, 0, 0),
                    new Equipment(EquipmentType.None, EquipmentSlot.None)
                );
            case PvETarget.Dogo:
                return new Character(
                    CharacterType.Dogo,
                    new Stats(20, 3, 2, 0, 0, 0),
                    new Equipment(EquipmentType.None, EquipmentSlot.None)
                );
            case PvETarget.DaphneBlake:
                return new Character(
                    CharacterType.DaphneBlake,
                    new Stats(25, 4, 3, 1, 1, 1),
                    new Equipment(EquipmentType.None, EquipmentSlot.None)
                );
            case PvETarget.Thug:
                return new Character(
                    CharacterType.Thug,
                    new Stats(30, 5, 4, 2, 2, 2),
                    new Equipment(EquipmentType.Club, EquipmentSlot.Weapon)
                );
            case PvETarget.Sellsword:
                return new Character(
                    CharacterType.Sellsword,
                    new Stats(35, 6, 5, 3, 3, 3),
                    new Equipment(EquipmentType.Sword, EquipmentSlot.Weapon)
                );
            case PvETarget.Uruk:
                return new Character(
                    CharacterType.Uruk,
                    new Stats(40, 7, 6, 4, 4, 4),
                    new Equipment(EquipmentType.Axe, EquipmentSlot.Weapon)
                );
            case PvETarget.Legolas:
                return new Character(
                    CharacterType.Legolas,
                    new Stats(45, 8, 7, 5, 5, 5),
                    new Equipment(EquipmentType.Bow, EquipmentSlot.Weapon)
                );
            case PvETarget.Batman:
                return new Character(
                    CharacterType.Batman,
                    new Stats(50, 9, 8, 6, 6, 6),
                    new Equipment(EquipmentType.Batarang, EquipmentSlot.Weapon)
                );
            default:
                throw new Error(`Unknown PvE target: ${target}`);
        }
    }
} 