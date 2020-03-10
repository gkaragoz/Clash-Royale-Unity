using UnityEngine;

namespace Custom {

    [CreateAssetMenu(fileName = "Animation Group", menuName = "Scriptable Objects/Animations/Animation Group")]
    public class AnimationGroup_SO : ScriptableObject {

        [Header("Initializations")]
        [SerializeField]
        private AnimationEntity[] _animationEntities;

    }
}

