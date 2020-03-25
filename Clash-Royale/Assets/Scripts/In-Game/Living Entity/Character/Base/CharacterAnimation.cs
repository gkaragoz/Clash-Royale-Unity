using Pathfinding;
using UnityEngine;

public class CharacterAnimation : MonoBehaviour {

    [Header("Debug")]
    [SerializeField]
    [Utils.ReadOnly]
    private float _characterAngle;
    [SerializeField]
    [Utils.ReadOnly]
    private MyAgent myAgent = null;
    [SerializeField]
    [Utils.ReadOnly]
    private AnimationManager _animationManager;
    [SerializeField]
    [Utils.ReadOnly]
    private Direction _currentDirection;

    private void Awake() {
        myAgent = GetComponent<MyAgent>();
        _animationManager = GetComponentInChildren<AnimationManager>();
    }

    private void Update() {
        if (myAgent == null)
            return;

        SetInputParams();
    }

    private void SetInputParams() {
        if (!myAgent.IsReached()) {            
            // Vector2.Angle gives a float value between 0-180. Needed negative y area.
            if (myAgent.GetVelocity().y < 0) {
                _characterAngle = 360 - ExtensionMethods.GetAngleFromVector2(myAgent.GetVelocity());
            } else {
                _characterAngle = ExtensionMethods.GetAngleFromVector2(myAgent.GetVelocity());
            }

            _currentDirection = _characterAngle.GetDirection();
            _animationManager.RunAnimation(AnimationType.Run, _currentDirection);
        } else {
            // Is Running or Idle.
            _animationManager.RunAnimation(AnimationType.Idle, _currentDirection);
        }


    }

}
