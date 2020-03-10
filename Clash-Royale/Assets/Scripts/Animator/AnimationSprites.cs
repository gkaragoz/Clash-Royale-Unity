using UnityEngine;

namespace Custom {

    [System.Serializable]
    public class AnimationSprites {

        [Header("Initializations")]
        [SerializeField]
        private AnimationDirection _direction;
        [SerializeField]
        private Sprite[] _sprites = new Sprite[8];

    }
}
