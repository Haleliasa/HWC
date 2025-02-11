using HWC.API;
using UnityEngine;

namespace HWC {
    public class Bootstrap : MonoBehaviour {
        [SerializeField]
        private Battlefield.Battlefield battlefield;

        [SerializeField]
        private new Camera camera;

        private const string logTag = nameof(Bootstrap);

        private GameController gameController;

        private void Start() {
            IGameService gameService;
            ILogger logger = Debug.unityLogger;

#if INPROCESS_SERVER
            gameService = new Server.GameService();
#else
            logger.LogError(logTag, "No remote game service", this);
            Utils.Quit();

            return;
#endif

            this.battlefield.Init(this.camera);

            this.gameController = new(gameService, this.battlefield, logger);
            this.gameController.Start();
        }
    }
}
