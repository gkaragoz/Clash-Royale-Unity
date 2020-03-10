using UnityEngine;

namespace Custom {
    public class AnimationManager : MonoBehaviour {

        [Header("Initialization")]
        [SerializeField]
        private AnimationGroup_SO _animationEntityDefinition_Template = null;

        [Header("Debug")]
        [SerializeField]
        private AnimationGroup_SO _animationEntity = null;

        #region Initializations

        private void Awake() {
            if (_animationEntityDefinition_Template != null) {
                _animationEntity = Instantiate(_animationEntityDefinition_Template);
            }
        }

        #endregion

    }
}
