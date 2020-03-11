using UnityEngine;

namespace Custom {

    [System.Serializable]
    public class AnimationEntity {

        [Header("Initializations")]
        [SerializeField]
        private AnimationType _animationType = AnimationType.Idle;
        [SerializeField]
        private AnimationSprites[] animationSprites = null;

        public AnimationType AnimationType { 
            get {
                return _animationType;
            } 
        }

        public Sprite[] GetFrames(AnimationDirection direction) {
            return animationSprites[(int)direction].Sprites;
        }

    }
}
