namespace HWC.API {
    public struct AbilityCooldown {
        public AbilityType type;
        public int unitIndex;
        public int? time;

        public AbilityCooldown(AbilityType type, int unitIndex, int? time) {
            this.type = type;
            this.unitIndex = unitIndex;
            this.time = time;
        }
    }
}
