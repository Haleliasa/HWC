namespace HWC.API {
    public struct Battle {
        public int id;
        public Unit playerUnit;
        public Unit enemyUnit;

        public Battle(int id, Unit playerUnit, Unit enemyUnit) {
            this.id = id;
            this.playerUnit = playerUnit;
            this.enemyUnit = enemyUnit;
        }
    }
}
