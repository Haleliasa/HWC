using UnityEngine;
using UnityEngine.Animations;

namespace HWC.Characters {
    public class CharacterStatus : MonoBehaviour {
        [SerializeField]
        private LookAtConstraint lookAtConstraint;

        public void Init(Camera camera) {
            this.lookAtConstraint.AddSource(new ConstraintSource {
                sourceTransform = camera.transform,
                weight = 1f,
            });
            this.lookAtConstraint.constraintActive = true;
        }
    }
}
