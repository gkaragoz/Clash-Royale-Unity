using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyAgent : VersionedMonoBehaviour {

    [Header("Initializations")]
    [SerializeField]
    public float searchTime = 0.1f;
    [SerializeField]
    public bool shouldSearch = true;
    [SerializeField]
    public Transform[] goals;

    [Header("Debug")]
    [SerializeField]
    [Utils.ReadOnly]
    private List<Vector3> _goalVectors;
    [SerializeField]
    [Utils.ReadOnly]
    private Vector3 _currentDestination;
    [SerializeField]
    [Utils.ReadOnly]
    private Seeker _seeker;
    [SerializeField]
    [Utils.ReadOnly]
    private AIPath _aiPath;

    private void Start() {
        _seeker = GetComponent<Seeker>();
        _aiPath = GetComponent<AIPath>();

        _goalVectors = new List<Vector3>();
        foreach (Transform goal in goals) {
            _goalVectors.Add(goal.position);
        }

        StartCoroutine(ISearch());
    }

    private IEnumerator ISearch() {
        while (shouldSearch) {
            if (HasTargetReached()) {
                OnTargetReached();
            }

            MultiTargetPath MTP = _seeker.StartMultiTargetPath(transform.position, _goalVectors.ToArray(), false);
            _currentDestination = MTP.endPoint;

            Debug.Log("endPoint: " + MTP.endPoint);
            Debug.Log("originalEndPoint: " + MTP.originalEndPoint);

            yield return new WaitForSeconds(searchTime);
        }
    }

    private bool HasTargetReached() {
        float distance = Vector3.Distance(transform.position, _currentDestination);
        //Debug.Log(distance + " me: " + transform.position + "  currentDestination: " + _currentDestination);

        return distance <= _aiPath.endReachedDistance ? true : false;
    }

    public void OnTargetReached() {
        _goalVectors.Remove(_currentDestination);
    }

}