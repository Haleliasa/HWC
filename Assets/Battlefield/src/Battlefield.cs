using UnityEngine;

namespace HWC.Battlefield {
    public class Battlefield : MonoBehaviour {
        [SerializeField]
        private Character playerCharacter;

        [SerializeField]
        private Character enemyCharacter;

        public Character PlayerCharacter => this.playerCharacter;

        public Character EnemyCharacter => this.enemyCharacter;
    }
}
