using Pathfinding;
using UnityEngine;

public class CharacterManager : MonoBehaviour {

    [Header("Debug")]
    [SerializeField]
    [Utils.ReadOnly]
    private float _angleCharacter;
    [SerializeField]
    [Utils.ReadOnly]
    private AIPath _AIPath = null;
    [SerializeField]
    [Utils.ReadOnly]
    private Animator _anim;

    private void Awake() {
        _AIPath = GetComponent<AIPath>();
        _anim = GetComponentInChildren<Animator>();
    }

    private void Update() {
        if (_AIPath == null)
            return;

        // Vector2.Angle gives a float value between 0-180. Needed negative y area.
        if (_AIPath.desiredVelocity.y < 0) {
            _angleCharacter = 360 - Vector2.Angle(_AIPath.desiredVelocity / _AIPath.maxSpeed, Vector2.right);
        } else {
            _angleCharacter = Vector2.Angle(_AIPath.desiredVelocity / _AIPath.maxSpeed, Vector2.right);
        }

        //Topdown rotationg angles
        if (_angleCharacter <= 30 && _angleCharacter > 330) {
            _anim.SetFloat("InputX", 1);
            _anim.SetFloat("InputY", 0);
        } else if (_angleCharacter > 30 && _angleCharacter <= 60) {
            _anim.SetFloat("InputX", .5f);
            _anim.SetFloat("InputY", .5f);
        } else if (_angleCharacter > 60 && _angleCharacter <= 120) {
            _anim.SetFloat("InputX", 0);
            _anim.SetFloat("InputY", 1f);
        } else if (_angleCharacter > 120 && _angleCharacter <= 150) {
            _anim.SetFloat("InputX", -.5f);
            _anim.SetFloat("InputY", .5f);
        } else if (_angleCharacter > 150 && _angleCharacter <= 210) {
            _anim.SetFloat("InputX", -1);
            _anim.SetFloat("InputY", 0);
        } else if (_angleCharacter > 210 && _angleCharacter <= 240) {
            _anim.SetFloat("InputX", -.5f);
            _anim.SetFloat("InputY", -.5f);
        } else if (_angleCharacter > 240 && _angleCharacter <= 300) {
            _anim.SetFloat("InputX", 0);
            _anim.SetFloat("InputY", -1);
        } else if (_angleCharacter > 300 && _angleCharacter <= 330) {
            _anim.SetFloat("InputX", .5f);
            _anim.SetFloat("InputY", -.5f);
        }
    }
}
