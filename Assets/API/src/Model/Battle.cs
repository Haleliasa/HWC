namespace HWC.API {
    public struct Battle {
        public int id;
        public Unit[] units;

        public Battle(int id, Unit[] units) {
            this.id = id;
            this.units = units;
        }
    }
}
