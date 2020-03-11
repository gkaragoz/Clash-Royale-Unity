using UnityEngine;

namespace Custom {

    [System.Serializable]
    public class AnimationSprites {

        [Header("Initializations")]
        [SerializeField]
        private AnimationDirection _direction = AnimationDirection.Up;
        [SerializeField]
        private Sprite[] _sprites = new Sprite[8];

        public AnimationDirection Direction { 
            get {
                return _direction;
            }
        }

        public Sprite[] Sprites { 
            get {
                return _sprites;
            }
        }

    }
}
