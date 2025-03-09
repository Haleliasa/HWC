using HWC.API;

namespace HWC {
    public interface IGameController {
        void Start();

        void MakeTurn(AbilityType ability);
    }
}
