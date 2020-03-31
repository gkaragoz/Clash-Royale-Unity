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
    [SerializeField]
    private bool _isSearchingEnemy = false;
    [SerializeField]
    private float _targetDedectionRadius = 2f;

    [Header("Debug")]
    [SerializeField]
    [Utils.ReadOnly]
    private List<Transform> _enemyTargets = null; //////////////////
    [SerializeField]
    [Utils.ReadOnly]
    private List<Transform> _targetTransforms = null; //////////////////
    [SerializeField]
    [Utils.ReadOnly]
    private Transform _currentTarget; //////////////////
    [SerializeField]
    [Utils.ReadOnly]
    private Seeker _seeker = null;
    [SerializeField]
    [Utils.ReadOnly]
    private GameManager _gameManager = null;

    private Coroutine _startCoroutine;

    public Transform CurrentTarget
    {

        get {
            return _currentTarget; //////////////////
        }
    }

    private void Awake() {
        _seeker = GetComponent<Seeker>();
        _gameManager = GameObject.Find("__GameManager").GetComponent<GameManager>();
           
    }

    private IEnumerator IStartSearch() {
        _isSearching = true;

        while (_isSearching) {
            MovebleTargets();
            GetEnemyTargets();
             if (_enemyTargets.Count>0)
               {
                StartFollowEnemy();
                StopSearch();
               }
           _seeker.StartMultiTargetPath(transform.position, GetVectorOfTargets(), false, OnPathComplete, _seeker.graphMask);
            
            yield return new WaitForSeconds(_searchRate);
        }
    }

    private IEnumerator IStartFollowEnemy()
    {
        _isSearchingEnemy = true;

        while (_isSearchingEnemy)
        {
            MovebleTargets();
            GetEnemyTargets();
            if (_enemyTargets.Count <= 0)
            {
                StartSearch();
                StopFollowEnemy();
            }
            _seeker.StartMultiTargetPath(transform.position, GetVectorOfEnemyTargets(), false, OnPathComplete, _seeker.graphMask);

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
        StartCoroutine(IStartSearch());
    }

    public void StopSearch() {
        _isSearching = false;
    }



    public void StartFollowEnemy()
    {
        StartCoroutine(IStartFollowEnemy());
    }

    public void StopFollowEnemy()
    {
        _isSearchingEnemy = false;
    }



    public void AddTarget(Transform target) {
    
    }

    /// <summary>
    /// Called on target reached. <see cref="OnPathReached"/>
    /// </summary>
    /// <param name="targetPosition"></param>
    public void RemoveTarget(Transform reachedTarget) {
        
    }

 

    public void MovebleTargets()
    {
        foreach (var item in _gameManager.movebleTargets)
        {
          
                if (!_targetTransforms.Contains(item)&&item.position.y>transform.position.y)
                {
                    _targetTransforms.Add(item);
                }
             
            
        }
    }


    public Vector3[] GetVectorOfTargets()
    {
        Vector3[] targetPositions = new Vector3[_targetTransforms.Count];

        for (int i = 0; i < _targetTransforms.Count; i++)
        {
            if (_targetTransforms[i].position.y>transform.position.y)
            {
                targetPositions[i] = _targetTransforms[i].position + Vector3.up * .6f;
            }
                              
        }

        return targetPositions;
    }


    public void GetEnemyTargets()
    {
        foreach (var item in _gameManager.enemyTargets)
        {

            if (!_enemyTargets.Contains(item) && Vector3.Distance(item.position,transform.position)<_targetDedectionRadius)
            {
                _enemyTargets.Add(item);
            }
           

        }
    }



    public Vector3[] GetVectorOfEnemyTargets()
    {
        Vector3[] targetPositions = new Vector3[_enemyTargets.Count];

        for (int i = 0; i < _enemyTargets.Count; i++)
        {

            if (_enemyTargets[i].gameObject.activeSelf && Vector3.Distance(_enemyTargets[i].position, transform.position) < _targetDedectionRadius)
            {
                targetPositions[i] = _enemyTargets[i].position;

            }
            else
            {
                _enemyTargets.Remove(_enemyTargets[i]);
            }


        }

        return targetPositions;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StopSearch();
            Debug.Log("MKust Stop");
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            StartSearch();
        }
    }

}


