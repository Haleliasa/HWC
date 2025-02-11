#nullable enable

using HWC.API;
using HWC.Characters;
using System.Threading.Tasks;
using UnityEngine;

namespace HWC {
    public class GameController : IGameController {
        private readonly IGameService gameService;
        private readonly Battlefield.Battlefield battlefield;
        private readonly Character[] characters;

        private readonly TaskQueue<Turn> turnQueue = new(capacity: 2);

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

        public void Start() {
            this.StartInternal().FireAndForget();
        }

        public void MakeTurn(AbilityType ability) {
            if (!this.CheckBattleActive(out int battleId)) {
                return;
            }

            this.MakeTurnInternal(battleId, ability).FireAndForget();
        }

        private async Task StartInternal() {
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
                Utils.Quit();

                return;
            }

            this.battleId = battle.id;

            this.ResetCharacter(this.battlefield.PlayerCharacter, ref battle.playerUnit);
            this.ResetCharacter(this.battlefield.EnemyCharacter, ref battle.enemyUnit);
        }

        private async Task MakeTurnInternal(int battleId, AbilityType ability) {
            Result res = await this.gameService.MakeTurn(battleId, ability);

            if (!res.IsOk(out Error error)) {
                this.logger.LogError(logTag, $"Turn error: {error}");
            }
        }

        private void OnTurn(Turn turn) {
            if (!this.CheckBattleActive(out int battleId)) {
                return;
            }

            if (turn.buttleId != battleId) {
                this.logger.LogError(logTag, "Turn battle id differs from active battle id");

                return;
            }

            this.turnQueue.Enqueue(turn => this.ProcessTurn(turn), turn);
        }

        private async void OnFinish(BattleFinish finish) {
            if (!this.CheckBattleActive(out int battleId)) {
                return;
            }

            if (finish.battleId != battleId) {
                this.logger.LogError(logTag, "Finish battle id differs from active battle id");

                return;
            }

            if (this.turnQueue.Running != null) {
                await this.turnQueue.Running;
            }

            this.logger.Log(logTag, $"Battle finished with status: {finish.status}");

            await Awaitable.WaitForSecondsAsync(1f);

            this.Start();
        }

        private async Task ProcessTurn(Turn turn) {
            
        }

        private void ResetCharacter(Character character, ref Unit unit) {
            character.Reset(unit.hp);
            this.characters[unit.index] = character;
        }

        private bool CheckBattleActive(out int battleId) {
            battleId = this.battleId ?? default;

            if (!this.battleId.HasValue) {
                this.logger.LogError(logTag, "No active battle");

                return false;
            }

            return true;
        }
    }
}
