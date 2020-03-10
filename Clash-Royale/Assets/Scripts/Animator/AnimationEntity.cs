using UnityEngine;

namespace Custom {

    [System.Serializable]
    public class AnimationEntity {

        [Header("Initializations")]
        [SerializeField]
        private AnimationType _animationType;
        [SerializeField]
        private AnimationSprites[] animationSprites;

    }
}
