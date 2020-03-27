using Pathfinding;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterPathfinder : MonoBehaviour {

    public Action<Path> OnPathFound;
    public Action<Path> OnPathChanged;

    [Header("Initializations")]
    [SerializeField]
    private float _searchRate = 0.2f;
    [SerializeField]
    private bool _isSearching = false;

    [Header("Debug")]
    [SerializeField]
    [Utils.ReadOnly]
    private List<Vector3> _targetPositions = null; //////////////////
    [SerializeField]
    [Utils.ReadOnly]
    private Transform _currentTarget; //////////////////
    [SerializeField]
    [Utils.ReadOnly]
    private Seeker _seeker = null;

    private Coroutine _startCoroutine;

    public Transform CurrentTarget {
        get {
            return _currentTarget; //////////////////
        }
    }

    private void Awake() {
        _seeker = GetComponent<Seeker>();
    }

    private IEnumerator IStartSearch() {
        _isSearching = true;

        while (_isSearching) {
            _seeker.StartMultiTargetPath(transform.position, _targetPositions.ToArray(), false, OnPathComplete, _seeker.graphMask);

            yield return new WaitForSeconds(_searchRate);
        }
    }

    private void OnPathComplete(Path path) {
        if (path.error) {
            Debug.LogWarning(path.errorLog);
            return;
        }

        OnPathFound?.Invoke(path);
    }

    public void StartSearch() {
        StopSearch();

        StartCoroutine(IStartSearch());
    }

    public void StopSearch() {
        _isSearching = false;
    }

    public void AddTarget() {
        ///////////////////////////////////////////
    }

    /// <summary>
    /// Called on target reached. <see cref="OnPathReached"/>
    /// </summary>
    /// <param name="targetPosition"></param>
    public void RemoveTarget(Vector3 targetPosition) {
        ///////////////////////////////////////////
    }

}
