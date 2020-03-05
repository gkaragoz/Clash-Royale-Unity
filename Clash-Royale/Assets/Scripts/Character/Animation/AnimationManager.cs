using Pathfinding;
using UnityEngine;

public class AnimationManager : MonoBehaviour {

    [Header("Initializations")]
    public Seeker seeker;
    public Transform target;

    [Header("Debug")]
    [SerializeField]
    [Utils.ReadOnly]
    private int _currentWayPoint;
    [SerializeField]
    [Utils.ReadOnly]
    private Path _currentPath;
    [SerializeField]
    [Utils.ReadOnly]
    private Animator _anim;

    public bool HasPath { 
        get {
            return _currentPath == null ? false : true;
        }
    }

    public bool HasPathCompleted {
        get {
            return HasPath && _currentWayPoint >= _currentPath.vectorPath.Count;
        }
    }

    private void Awake() {
        seeker = GetComponent<Seeker>();
        _anim = GetComponent<Animator>();
    }

    private void Start() {
        seeker.StartPath(transform.position, target.position, OnPathCompleted);
    }

    private void FixedUpdate() {
        if (HasPath && HasPathCompleted) {
            return;
        }

        Vector3 normalizedDesiredVelocity = (transform.position - _currentPath.vectorPath[_currentWayPoint]).normalized;
        
        //Report the path using the delegate
        _anim.SetFloat("InputX", normalizedDesiredVelocity.x);
        _anim.SetFloat("InputY", normalizedDesiredVelocity.y);
    }

    private void OnPathCompleted(Path path) {
        if (!path.error) {
            _currentPath = path;
            _currentWayPoint = 0;
        } else {
            Debug.Log(path.error);
        }
    }

}
