namespace HWC.API {
    public struct BattleFinish {
        public int battleId;
        public BattleFinishStatus status;

        public BattleFinish(int battleId, BattleFinishStatus status) {
            this.battleId = battleId;
            this.status = status;
        }
    }
}
