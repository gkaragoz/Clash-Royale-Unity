using UnityEngine;
using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using Pathfinding.RVO;

public class MyAgent : MonoBehaviour {
    [Header("Initializations")]
    [SerializeField]
    private List<Transform> _targetTransforms = null;
    [SerializeField]
    private float _searchRate = 0.2f;
    [SerializeField]
    private float _maxSpeed = 2;
    [SerializeField]
    private float _nextWaypointDistance = 0.2f;

    [Header("Debug")]
    [SerializeField]
    [Utils.ReadOnly]
    private RVOController _rvo;
    [SerializeField]
    [Utils.ReadOnly]
    private Path _currentPath = null;
    [SerializeField]
    [Utils.ReadOnly]
    private Seeker _seeker = null;
    [SerializeField]
    [Utils.ReadOnly]
    private int _currentWaypoint = 0;
    [SerializeField]
    [Utils.ReadOnly]
    private bool _reachedEndOfPath = false;
    [SerializeField]
    private Vector3 _currentVelocity = Vector3.zero;

    private Coroutine _startCoroutine;

    public Vector2 GetVelocity() {
        return new Vector2(_currentVelocity.x, _currentVelocity.y);
    }

    public bool HasReachedToDestination() {
        return _reachedEndOfPath;
    }

    public void Start() {
        _seeker = GetComponent<Seeker>();
        _rvo = GetComponent<RVOController>();
        
        _startCoroutine = StartCoroutine(IStart());
    }

    private IEnumerator IStart() {
        while (true) {
            _seeker.StartMultiTargetPath(transform.position, GetGoalVectors(), false, OnPathComplete, _seeker.graphMask);
            yield return new WaitForSeconds(_searchRate);
        }
    }

    private void Stop() {
        if (_startCoroutine == null)
            return;

        StopCoroutine(_startCoroutine);
    }

    private Vector3[] GetGoalVectors() {
        Vector3[] goalVectors = new Vector3[_targetTransforms.Count];

        for (int ii = 0; ii < goalVectors.Length; ii++) {
            if (_targetTransforms[ii] == null)
                continue;
          
          //  goalVectors[ii] = _targetTransforms[ii].position;
            goalVectors[ii] = SetTargetFinalPPosition(_targetTransforms[ii]);
        }

        return goalVectors;
    }

    public void OnPathComplete(Path p) {
        if (p.error) {
            Debug.LogError(p.errorLog);
            Stop();
            return;
        }
        _currentPath = p;
        _currentWaypoint = 0;
    }

    private void Update() {
        if (_currentPath == null) {
            return;
        }


        _reachedEndOfPath = false;
        float distanceToWaypoint;

        while (true) {

            distanceToWaypoint = Vector3.Distance(transform.position, _currentPath.vectorPath[_currentWaypoint]);
            if (distanceToWaypoint < _nextWaypointDistance) {
                if (_currentWaypoint + 1 < _currentPath.vectorPath.Count) {
                    


                    _currentWaypoint++;
                }
                else {
                    _reachedEndOfPath = true;

                    DestroyTarget();
                    break;
                }
            } else {
                break;
            }
        }

        var speedFactor = _reachedEndOfPath ? Mathf.Sqrt(distanceToWaypoint / _nextWaypointDistance) : 1f;

        Vector3 dir = (_currentPath.vectorPath[_currentWaypoint] - transform.position).normalized;
        _currentVelocity = dir * _maxSpeed * speedFactor;

        _rvo.SetTarget(_currentPath.vectorPath[_currentWaypoint], _maxSpeed, _maxSpeed+2);
        var delta = _rvo.CalculateMovementDelta(transform.position, Time.deltaTime);

        transform.position = transform.position + delta;
    }

    private void DestroyTarget() {
        Transform willRemoveTransform = null;
        for (int ii = 0; ii < _targetTransforms.Count; ii++) {

            if (/*_targetTransforms[ii].position == _currentPath.vectorPath[_currentWaypoint] || */Vector3.Distance(_targetTransforms[ii].position, _currentPath.vectorPath[_currentWaypoint])<2f) {
                willRemoveTransform = _targetTransforms[ii];

                break;
            }
        }
        _targetTransforms.Remove(willRemoveTransform);
    }



    public Vector3 SetTargetFinalPPosition(Transform target)
    {
        Vector3 targetDir = target.position - transform.position;

        return target.position - targetDir.normalized;
    }


    public void AddTarget(Transform target)
    {
        _targetTransforms.Add(target);
    }

}