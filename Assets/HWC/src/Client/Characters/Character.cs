using UnityEngine;

namespace HWC.Characters {
    public class Character : MonoBehaviour {
        [SerializeField]
        private CharacterStatus status;

        private int hp;

        public void Init(Camera camera) {
            this.status.Init(camera);
        }

        public void Reset(int hp) {
            this.hp = hp;
        }
    }
}
