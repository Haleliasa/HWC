namespace HWC.API {
    public struct Effect {
        public int unitId;
        public EffectType type;
        public int value;
        public int duration;

        public Effect(int unitId, EffectType type, int value, int duration) {
            this.unitId = unitId;
            this.type = type;
            this.value = value;
            this.duration = duration;
        }
    }
}
