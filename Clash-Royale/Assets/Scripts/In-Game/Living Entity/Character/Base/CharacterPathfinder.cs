using Pathfinding;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterPathfinder : MonoBehaviour
{

    public Transform currentEnemy;
    public Action<Path> OnPathFound;
    public Action<Path> OnPathChanged;
    public bool isEnemyInRange = false;


    [Header("Initializations")]
    [SerializeField]
    private float _targetDedectionRadius = 2f;

    [Header("Debug")]

    [SerializeField]
    [Utils.ReadOnly]
    public Transform _currentTarget; //////////////////

    [SerializeField]
    [Utils.ReadOnly]
    private GameManager _gameManager = null;

    private List<Transform> myTargets;
    private LivingEntityTypes[] myAttackables;


    private void Start()
    {
        _gameManager = GameObject.Find("__GameManager").GetComponent<GameManager>();
        myAttackables = GetComponent<Pose>().TypesOfAttackTargets;

    }
    public Transform GetClosestMovementPoint()
    {
        Transform target = null;
        float distance = 50;//Doesnt matter it must be a big number 

        foreach (var item in _gameManager.movebleTargets)
        {
            float tempDistance = Vector3.Distance(transform.position, item.position);
            if (item.position.y < transform.position.y)
            {
                if (tempDistance < distance)
                {
                    target = item;
                    distance = tempDistance;
                }
            }

        }
        return target;
    }

    public Transform GetEnemyInRange()
    {
        Transform target = null;
        myTargets = _gameManager.myTargetList;
        float distance = 50;

        foreach (var item in myTargets)
        {
            float tempDistance = Vector3.Distance(transform.position, item.position);

            if (tempDistance < _targetDedectionRadius) //&& IsItMyType(item.GetComponent<StandardChars>()))
            {
                if (tempDistance < distance)
                {
                    target = item;
                    distance = tempDistance;
                }
            }

        }
     

        return target;
    }

    public bool IsItMyType(StandardChars target)
    {
        for (int ii = 0; ii < myAttackables.Length; ii++)
        {
            if (target.CharacterType==myAttackables[ii])
            {
                return true;
            }
        }
        return false;
    }

    public Vector3 GetClosestTargetPosition()
    {
        if (GetEnemyInRange()==null)
        {
            currentEnemy = null;
            return (GetClosestMovementPoint().position+Vector3.down*.6f);
            
        }
        else
        {
            currentEnemy = GetEnemyInRange();

            
            return GetEnemyInRange().position;
        }
    }



    //Action bağlanacak
    private void Update()
    {      

        if (currentEnemy!=null)
        {

        if (!currentEnemy.gameObject.activeSelf)
        {
            currentEnemy = null;
        }
        }
    }



}


