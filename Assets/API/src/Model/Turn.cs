namespace HWC.API {
    public struct Turn {
        public int buttleId;
        public Unit[] units;
        public Ability[] abilities;
        public Effect[] effects;

        public Turn(int battleId, Unit[] units, Ability[] abilities, Effect[] effects) {
            this.buttleId = battleId;
            this.units = units;
            this.abilities = abilities;
            this.effects = effects;
        }
    }
}
