using HWC.API;
using System;
using System.Threading.Tasks;

namespace HWC.Server {
    public class GameService : IGameService {
        public Task<Result<Battle>> StartBattle(
            Action<Turn> onTurn,
            Action<BattleFinishStatus> onFinish
        ) {
            throw new NotImplementedException();
        }

        public Task<Result> MakeTurn(int battleId, AbilityType ability) {
            throw new NotImplementedException();
        }

        public Task<Result> CancelBattle(int id) {
            throw new NotImplementedException();
        }
    }
}
