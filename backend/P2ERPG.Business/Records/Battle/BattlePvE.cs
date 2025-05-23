﻿using BilbolStack.Boonamai.P2ERPG.Business.Records.Characters;
using BilbolStack.Boonamai.P2ERPG.Common.Enumeration;

namespace BilbolStack.Boonamai.P2ERPG.Business.Records.Battle
{
    public record BattlePvE(Character attacker, WeaponType attWeaponType, ShieldType attShieldType, ArmorType attArmorType, PvETarget target);
}