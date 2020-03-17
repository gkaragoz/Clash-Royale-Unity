using UnityEngine;

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
        set {
            _animationType = value;
        }
    }

    public AnimationSprites[] AnimationSprites { 
        get {
            return animationSprites;
        } 
        set {
            animationSprites = value;
        }
    }

    public Sprite[] GetFrames(Direction direction) {
        return animationSprites[(int)direction].Sprites;
    }

}
