using System.Collections;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class AnimationManager : MonoBehaviour {

    [Header("Initialization")]
    [SerializeField]
    private AnimationGroup_SO _animationGroupDefinition_Template = null;
    [SerializeField]
    private int _frameRate = 30;

    [Header("Debug")]
    [SerializeField]
    private AnimationType _currentAnimationType;
    [SerializeField]
    private Direction _currentAnimationDirection;
    [SerializeField]
    [Utils.ReadOnly]
    private AnimationGroup_SO _animationGroup = null;

    private SpriteRenderer _spriteRenderer;
    private Coroutine _runCoroutine;

    #region Initializations

    private void Awake() {
        if (_animationGroupDefinition_Template != null) {
            _animationGroup = Instantiate(_animationGroupDefinition_Template);
        }

        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    #endregion

    public void RunAnimation(AnimationType type, Direction direction) {
        if (_currentAnimationType == type && _currentAnimationDirection == direction) {
            return;
        }

        _currentAnimationType = type;
        _currentAnimationDirection = direction;

        Sprite[] frames = _animationGroup.GetFrames(type, direction);

        if (_runCoroutine != null) {
            StopCoroutine(_runCoroutine);
        }

        _runCoroutine = StartCoroutine(IRun(frames));
    }

    private IEnumerator IRun(Sprite[] frames) {
        int index = 0;
        while (true) {
            _spriteRenderer.sprite = frames[index++];

            if (index >= frames.Length) {
                index = 0;
            }

            yield return new WaitForSeconds((float)1 / _frameRate);
        }
    }

}
