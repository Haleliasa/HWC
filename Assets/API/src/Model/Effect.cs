namespace HWC.API {
    public struct Effect {
        public int id;
        public int unitIndex;
        public EffectType type;
        public int value;
        public int duration;

        public Effect(
            int id,
            int unitIndex,
            EffectType type,
            int value,
            int duration
        ) {
            this.id = id;
            this.unitIndex = unitIndex;
            this.type = type;
            this.value = value;
            this.duration = duration;
        }
    }
}
