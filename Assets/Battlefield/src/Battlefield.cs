using HWC.Characters;
using UnityEngine;

namespace HWC.Battlefield {
    public class Battlefield : MonoBehaviour {
        [SerializeField]
        private Character playerCharacter;

        [SerializeField]
        private Character enemyCharacter;

        public Character PlayerCharacter => this.playerCharacter;

        public Character EnemyCharacter => this.enemyCharacter;

        public void Init(Camera camera) {
            this.playerCharacter.Init(camera);
            this.enemyCharacter.Init(camera);
        }
    }
}
