using HWC.API;
using System.Threading.Tasks;
using UnityEngine;

namespace HWC {
    public class GameController : IGameController {
        private readonly IGameService gameService;
        private readonly Battlefield.Battlefield battlefield;
        private readonly Character[] characters;

        private readonly ILogger logger;
        private const string logTag = nameof(GameController);

        private int? battleId;

        public GameController(
            IGameService gameService,
            Battlefield.Battlefield battlefield,
            ILogger logger
        ) {
            this.gameService = gameService;
            this.battlefield = battlefield;
            this.characters = new Character[] {
                battlefield.PlayerCharacter,
                battlefield.EnemyCharacter,
            };
            this.logger = logger;
        }

        public async Task<bool> Start() {
            Error error;

            if (this.battleId.HasValue) {
                Result cancelRes = await this.gameService.CancelBattle(this.battleId.Value);

                if (!cancelRes.IsOk(out error)) {
                    this.logger.LogError(logTag, $"Cancel error: {error}");
                }
            }

            this.battleId = null;

            Result<Battle> startRes = await this.gameService.StartBattle(
                this.OnTurn,
                this.OnFinish
            );

            if (!startRes.IsOk(out Battle battle, out error)) {
                this.logger.LogError(logTag, $"Start error: {error}");

                return false;
            }

            this.battleId = battle.id;

            this.ResetCharacter(this.battlefield.PlayerCharacter, ref battle.playerUnit);
            this.ResetCharacter(this.battlefield.EnemyCharacter, ref battle.enemyUnit);

            return true;
        }

        public async void MakeTurn(AbilityType ability) {
            if (!this.battleId.HasValue) {
                this.logger.LogError(logTag, "No active battle");

                return;
            }

            Result res = await this.gameService.MakeTurn(this.battleId.Value, ability);

            if (!res.IsOk(out Error error)) {
                this.logger.LogError(logTag, $"Turn error: {error}");
            }
        }

        private void OnTurn(Turn turn) {
        }

        private void OnFinish(BattleFinishStatus status) {
        }

        private void ResetCharacter(Character character, ref Unit unit) {
            character.Reset(unit.hp);
            this.characters[unit.index] = character;
        }
    }
}
