using System;
using System.Threading.Tasks;

namespace HWC.API {
    public interface IGameService {
        Task<Result<Battle>> StartBattle(Action<Turn> onTurn, Action<BattleFinish> onFinish);

        Task<Result> MakeTurn(int battleId, AbilityType ability);

        Task<Result> CancelBattle(int id);
    }
}
