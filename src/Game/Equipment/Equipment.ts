import { EquipmentType } from './EquipmentType';
import { EquipmentSlot } from './EquipmentSlot';

export class Equipment {
    constructor(
        public type: EquipmentType,
        public slot: EquipmentSlot
    ) {}
} 