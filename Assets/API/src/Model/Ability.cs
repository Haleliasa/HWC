namespace HWC.API {
    public struct Ability {
        public AbilityType type;
        public int unitId;
        public int targetUnitId;
        public Effect[] effects;

        public Ability(AbilityType type, int unitId, int targetUnitId, Effect[] effects) {
            this.type = type;
            this.unitId = unitId;
            this.targetUnitId = targetUnitId;
            this.effects = effects;
        }
    }
}
