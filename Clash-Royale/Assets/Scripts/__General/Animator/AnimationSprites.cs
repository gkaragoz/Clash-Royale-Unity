using UnityEngine;

[System.Serializable]
public class AnimationSprites {

    [Header("Initializations")]
    [SerializeField]
    private Direction _direction = Direction.Up;
    [SerializeField]
    private Sprite[] _sprites = new Sprite[8];

    public Direction Direction {
        get {
            return _direction;
        }
        set {
            _direction = value;
        }
    }

    public Sprite[] Sprites {
        get {
            return _sprites;
        }
        set {
            _sprites = value;
        }
    }

}
