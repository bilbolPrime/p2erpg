import { CharacterType } from './CharacterType';
import { Equipment } from '../Equipment/Equipment';
import { Stats } from '../Stats/Stats';

export class Character {
    constructor(
        public type: CharacterType,
        public stats: Stats,
        public equipment: Equipment | null
    ) {}
} 