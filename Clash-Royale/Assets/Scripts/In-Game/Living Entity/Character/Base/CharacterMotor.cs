using Pathfinding;
using Pathfinding.RVO;
using System;
using UnityEngine;

public class CharacterMotor : MonoBehaviour {

    public Action OnTargetReached;

    [Header("Initializations")]
    [SerializeField]
    private float _maxSpeed = 2;    // PUT THIS VALUE INSIDE CHARACTER STATS. NOT NOW BECAUSE WE DIDN'T COMPLETE THE MOVEMENT AND ATTACK SYSTEM. THIS IS NEEDED FOR QUICKLY CHANGED VALUE.
    [SerializeField]
    private float _nextWaypointDistance = 0.2f;
    [SerializeField]
    private bool _isMoving = true;

    [Header("Debug")]
    [SerializeField]
    [Utils.ReadOnly]
    private RVOController _rvo;
    [SerializeField]
    [Utils.ReadOnly]
    private Path _currentPath = null;
    [SerializeField]
    [Utils.ReadOnly]
    private int _currentWaypoint = 0;
    [SerializeField]
    [Utils.ReadOnly]
    private bool _reachedEndOfPath = false;

    public Vector2 GetCurrentVelocity() {
        return _rvo.velocity;
    }

    public bool HasReachedToDestination() {
        return _reachedEndOfPath;
    }

    private void Awake() {
        _rvo = GetComponent<RVOController>();
    }

    private void Update() {
        if (_currentPath == null || _isMoving == false) {
            return;
        }

        ProcessNextWaypoint();
        ProcessMovement();
    }

    /// <summary>
    /// Finally update my position depends on what RVO decided to.
    /// </summary>
    private void ProcessMovement() {
        transform.position += GetCalculatedRVOPosition();
    }

    /// <summary>
    /// Works via our current node point and next node point that calculates which direction that we have atm.
    /// Then, set our RVO
    /// </summary>
    /// <returns></returns>
    private Vector3 GetCalculatedRVOPosition() {
        _rvo.SetTarget(_currentPath.vectorPath[_currentWaypoint], _maxSpeed, _maxSpeed * 1.2f);
        return _rvo.CalculateMovementDelta(transform.position, Time.deltaTime);
    }

    /// <summary>
    /// Check next waypoint while moving along the current path. <see cref="_currentPath"/>
    /// If we got the last position of the path, than invoke <see cref="OnTargetReached"/>
    /// </summary>
    private void ProcessNextWaypoint() {
        _reachedEndOfPath = false;
        float distanceToWaypoint;

        while (true) {
            distanceToWaypoint = Vector3.Distance(transform.position, _currentPath.vectorPath[_currentWaypoint]);
            if (distanceToWaypoint < _nextWaypointDistance) {
                if (_currentWaypoint + 1 < _currentPath.vectorPath.Count) {
                    _currentWaypoint++;
                } else {
                    _reachedEndOfPath = true;

                    OnTargetReached?.Invoke();
                    break;
                }
            } else {
                break;
            }
        }
    }

    public void SetPath(Path targetPath) {
        _currentWaypoint = 0;
        _reachedEndOfPath = false;

        _currentPath = targetPath;
    }

    public void StartMovement() {
        _isMoving = true;
    }

    public void StopMovement() {
        _isMoving = false;
    }

}
