import { Character } from '../Character/Character';

export type BattleResult = {
    winner: Character;
    loser: Character;
    damageDealt: number;
    damageTaken: number;
}; 