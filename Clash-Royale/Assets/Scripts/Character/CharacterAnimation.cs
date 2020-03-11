using Pathfinding;
using UnityEngine;

public class CharacterAnimation : MonoBehaviour {

    [Header("Debug")]
    [SerializeField]
    [Utils.ReadOnly]
    private float _characterAngle;
    [SerializeField]
    [Utils.ReadOnly]
    private AIPath _AIPath = null;
    [SerializeField]
    [Utils.ReadOnly]
    private AnimationManager _animationManager;
    [SerializeField]
    [Utils.ReadOnly]
    private Direction _currentDirection;

    private void Awake() {
        _AIPath = GetComponent<AIPath>();
        _animationManager = GetComponentInChildren<AnimationManager>();
    }

    private void Update() {
        if (_AIPath == null)
            return;

        SetInputParams();
    }

    private void SetInputParams() {
        if (!_AIPath.reachedDestination) {
            // Vector2.Angle gives a float value between 0-180. Needed negative y area.
            if (_AIPath.desiredVelocity.y < 0) {
                _characterAngle = 360 - ExtensionMethods.GetAngleFromVector2(_AIPath.desiredVelocity);
            } else {
                _characterAngle = ExtensionMethods.GetAngleFromVector2(_AIPath.desiredVelocity);
            }

            _currentDirection = _characterAngle.GetDirection();
            _animationManager.RunAnimation(AnimationType.Run, _currentDirection);
        }

        // Is Running or Idle.
        _animationManager.RunAnimation(AnimationType.Idle, _currentDirection);
    }

}
