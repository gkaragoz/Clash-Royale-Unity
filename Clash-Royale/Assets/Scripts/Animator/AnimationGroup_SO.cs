using UnityEngine;

[CreateAssetMenu(fileName = "Animation Group", menuName = "Scriptable Objects/Animations/Animation Group")]
public class AnimationGroup_SO : ScriptableObject {

    [Header("Initializations")]
    [SerializeField]
    private AnimationEntity[] _animationEntities = null;

    public Sprite[] GetFrames(AnimationType type, Direction direction) {
        return _animationEntities[(int)type].GetFrames(direction);
    }

}

