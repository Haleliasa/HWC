namespace HWC.API {
    public struct Turn {
        public int buttleId;
        public AbilityUse[] abilityUses;
        public AbilityCooldown[] abilityCooldowns;
        public Effect[] effectUpdates;

        public Turn(
            int battleId,
            AbilityUse[] abilityUses,
            AbilityCooldown[] abilityCooldowns,
            Effect[] effectUpdates
        ) {
            this.buttleId = battleId;
            this.abilityUses = abilityUses;
            this.abilityCooldowns = abilityCooldowns;
            this.effectUpdates = effectUpdates;
        }
    }
}
