using System.Collections.Generic;
using UnityEngine;

public class CharacterPathfinder : MonoBehaviour
{
    public Transform currentEnemy;

    [Header("Initializations")]
    [SerializeField]
    private float _targetDedectionRadius;
    private float _myPlayerId;

    [Header("Debug")]

    [SerializeField]
    [Utils.ReadOnly]
    public Transform _currentTarget; 


    private void Start()
    {
        _myPlayerId = GetComponent<LivingEntity>().GetPlayerId();
        _targetDedectionRadius = 7;
    }
    public Transform GetClosestMovementPoint()
    {
        Transform target = null;
        float distance = 50;//Doesnt matter it must be a big number 

        foreach (var item in TargetManager.instance.movebleTargets)
        {
            float tempDistance = Vector3.Distance(transform.position, item.position);
            if (_myPlayerId * item.position.y > _myPlayerId * transform.position.y)
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

        float distance = 50;

        foreach (var item in TargetManager.instance.GetMyTargetList(GetComponent<LivingEntity>()))
        {
            float tempDistance = Vector3.Distance(transform.position, item.position);

            if (tempDistance <= _targetDedectionRadius)
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


  

}



