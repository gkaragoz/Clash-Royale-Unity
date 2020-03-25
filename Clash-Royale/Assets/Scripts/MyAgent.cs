using UnityEngine;
using Pathfinding;
using System.Collections;
using System.Collections.Generic;

public class MyAgent : MonoBehaviour {

    [Header("Initializations")]
    [SerializeField]
    private List<Transform> _targetTransforms = null;
    [SerializeField]
    private float _searchRate = 0.2f;
    [SerializeField]
    private Path _currentPath = null;
    [SerializeField]
    private float _speed = 2;
    [SerializeField]
    private float _nextWaypointDistance = 0.2f;

    [Header("Debug")]
    [SerializeField]
    [Utils.ReadOnly]
    private Seeker _seeker = null;
    [SerializeField]
    [Utils.ReadOnly]
    private int _currentWaypoint = 0;
    [SerializeField]
    [Utils.ReadOnly]
    private bool _reachedEndOfPath = false;

    public void Start() {
        _seeker = GetComponent<Seeker>();

        StartCoroutine(IStart());
    }

    private IEnumerator IStart() {
        while (true) {
            _seeker.StartMultiTargetPath(transform.position, GetGoalVectors(), false, OnPathComplete);

            yield return new WaitForSeconds(_searchRate);
        }
    }

    private Vector3[] GetGoalVectors() {
        Vector3[] goalVectors = new Vector3[_targetTransforms.Count];

        for (int ii = 0; ii < goalVectors.Length; ii++) {
            if (_targetTransforms[ii] == null)
                continue;

            goalVectors[ii] = _targetTransforms[ii].position;
        }

        return goalVectors;
    }

    public void OnPathComplete(Path p) {
        if (!p.error) {
            _currentPath = p as MultiTargetPath;
            _currentWaypoint = 0;
        }
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
                } else {
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
        Vector3 velocity = dir * _speed * speedFactor;

        transform.position += velocity * Time.deltaTime;
    }

    private void DestroyTarget() {
        Transform willRemoveTransform = null;
        for (int ii = 0; ii < _targetTransforms.Count; ii++) {
            if (_targetTransforms[ii].position == _currentPath.vectorPath[_currentWaypoint]) {
                willRemoveTransform = _targetTransforms[ii];
                break;
            }
        }

        _targetTransforms.Remove(willRemoveTransform);
    }

}