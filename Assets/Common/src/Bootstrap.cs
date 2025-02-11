using HWC.API;
using UnityEngine;

namespace HWC {
    public class Bootstrap : MonoBehaviour {
        [SerializeField]
        private Battlefield.Battlefield battlefield;

        private const string logTag = nameof(Bootstrap);

        private GameController gameController;

        private async void Start() {
            IGameService gameService;
            ILogger logger = Debug.unityLogger;

#if INPROCESS_SERVER
            gameService = new Server.GameService();
#else
            logger.LogError(logTag, "No remote game service", this);
            Utils.Quit();

            return;
#endif

            this.gameController = new(
                gameService,
                this.battlefield,
                logger
            );

            if (!await this.gameController.Start()) {
                Utils.Quit();

                return;
            }
        }
    }
}
