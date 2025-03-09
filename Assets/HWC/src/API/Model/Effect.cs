namespace HWC.API {
    public struct Effect {
        public int index;
        public int unitIndex;
        public EffectType type;
        public int value;
        public int duration;

        public Effect(
            int index,
            int unitIndex,
            EffectType type,
            int value,
            int duration
        ) {
            this.index = index;
            this.unitIndex = unitIndex;
            this.type = type;
            this.value = value;
            this.duration = duration;
        }
    }
}
