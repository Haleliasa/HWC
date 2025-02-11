namespace HWC.API {
    public struct AbilityUse {
        public AbilityType type;
        public int unitIndex;
        public int targetUnitIndex;
        public Effect[] effects;

        public AbilityUse(
            AbilityType type,
            int unitIndex,
            int targetUnitIndex,
            Effect[] effects
        ) {
            this.type = type;
            this.unitIndex = unitIndex;
            this.targetUnitIndex = targetUnitIndex;
            this.effects = effects;
        }
    }
}
