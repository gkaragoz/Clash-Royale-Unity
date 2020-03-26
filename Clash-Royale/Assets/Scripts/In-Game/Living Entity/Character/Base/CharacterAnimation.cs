using UnityEngine;

public class CharacterAnimation : MonoBehaviour {

    [Header("Debug")]
    [SerializeField]
    [Utils.ReadOnly]
    private float _characterAngle;
    [SerializeField]
    [Utils.ReadOnly]
    private MyAgent _myAgent = null;
    [SerializeField]
    [Utils.ReadOnly]
    private AnimationManager _animationManager;
    [SerializeField]
    [Utils.ReadOnly]
    private Direction _currentDirection;

    private void Awake() {
        _myAgent = GetComponent<MyAgent>();
        _animationManager = GetComponentInChildren<AnimationManager>();
    }

    private void Update() {
        if (_myAgent == null)
            return;

        SetInputParams();
    }

    private void SetInputParams() {
        if (!_myAgent.HasReachedToDestination()) {
            Vector2 agentVelocity = _myAgent.GetVelocity();

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
