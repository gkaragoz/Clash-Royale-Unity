using Pathfinding;
using UnityEngine;

public class AnimationManager : MonoBehaviour {

    [Header("Debug")]
    [SerializeField]
    [Utils.ReadOnly]
    private float _characterAngle;
    [SerializeField]
    [Utils.ReadOnly]
    private AIPath _AIPath = null;
    [SerializeField]
    [Utils.ReadOnly]
    private Animator _anim;

    private InputVector _directionVector;

    private void Awake() {
        _AIPath = GetComponent<AIPath>();
        _anim = GetComponentInChildren<Animator>();
    }

    private void Update() {
        if (_AIPath == null)
            return;

        SetInputParams();
    }

    private void SetInputParams() {
        // Vector2.Angle gives a float value between 0-180. Needed negative y area.
        if (_AIPath.desiredVelocity.y < 0) {
            _characterAngle = 360 - AnimationExtensions.GetAngleFromVector2(_AIPath.desiredVelocity);
        } else {
            _characterAngle = AnimationExtensions.GetAngleFromVector2(_AIPath.desiredVelocity);
        }

        _directionVector = _characterAngle.GetDirectionVector();

        _anim.SetFloat("InputX", _directionVector.x);
        _anim.SetFloat("InputY", _directionVector.y);
    }

}
