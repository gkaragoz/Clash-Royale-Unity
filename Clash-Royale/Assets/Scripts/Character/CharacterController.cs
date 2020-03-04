using Pathfinding;
using UnityEngine;

public class CharacterController : MonoBehaviour {

    [Header("Debug")]
    [SerializeField]
    private AIPath _AIPath = null;

    private void Awake() {
        _AIPath = GetComponent<AIPath>();
    }

    private void Update() {
        if (_AIPath == null)
            return;

        Debug.Log(_AIPath.desiredVelocity);
    }


}
