using UnityEngine;

public class CharacterAnimation : MonoBehaviour {

    [Header("Debug")]
    [SerializeField]
    [Utils.ReadOnly]
    private float _characterAngle;
    [SerializeField]
    [Utils.ReadOnly]
    private MotorPose _characterMotor = null;
    [SerializeField]
    [Utils.ReadOnly]
    private AnimationManager _animationManager;
    [SerializeField]
    [Utils.ReadOnly]
    private Direction _currentDirection;

    private void Awake() {
        _characterMotor = GetComponent<MotorPose>();
        _animationManager = GetComponentInChildren<AnimationManager>();
    }

    private void Update() {
        if (_characterMotor == null)
            return;

        SetInputParams();
    }

    private void SetInputParams() {
        if (!_characterMotor.HasReachedToDestination()) {
            Vector2 agentVelocity = _characterMotor.GetCurrentVelocity();

            // Vector2.Angle gives a float value between 0-180. Needed negative y area.
            if (agentVelocity.y < 0) {
                _characterAngle = 360 - ExtensionMethods.GetAngleFromVector2(agentVelocity);
            } else {
                _characterAngle = ExtensionMethods.GetAngleFromVector2(agentVelocity);
            }

            _currentDirection = _characterAngle.GetDirection();
            _animationManager.RunAnimation(AnimationType.Run, _currentDirection);
        } else {
            // Is Running or Idle.
            _animationManager.RunAnimation(AnimationType.Idle, _currentDirection);
        }
    }

}
