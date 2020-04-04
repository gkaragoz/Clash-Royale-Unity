using UnityEngine;
// Note this line, if it is left out, the script won't know that the class 'Path' exists and it will throw compiler errors
// This line should always be present at the top of scripts which use pathfinding
using Pathfinding;
using Pathfinding.RVO;
using System.Collections;

public class MotorPose : MonoBehaviour
{
    bool isReached;

    Vector3 velocity;

    public bool _canMove = false;

    public bool _canDedectEnemy = false;

    public Transform targetPosition;

    public CharacterPathfinder characterPathfinder;

    private Seeker seeker;

    public Path path;

    public float speed = 2;

    public float nextWaypointDistance = 3;

    private int currentWaypoint = 0;

    public bool reachedEndOfPath;

    public void Start()
    {
        seeker = GetComponent<Seeker>();
        characterPathfinder = GetComponent<CharacterPathfinder>();
    }

    public void OnPathComplete(Path p)
    {
        //Debug.Log("A path was calculated. Did it fail with an error? " + p.error);

        if (!p.error)//P errrorsa return edilecek
        {
            path = p;
            currentWaypoint = 0;

            _canMove = true;
            reachedEndOfPath = false;
        }
    }

    public void Update()
    {    

        if (path == null)
        {
            return;
        }


        
        while (_canMove)
        {
           float distanceToWaypoint = Vector3.Distance(transform.position, path.vectorPath[currentWaypoint]);
            if (distanceToWaypoint < nextWaypointDistance)
            {
                if (currentWaypoint + 1 < path.vectorPath.Count)
                {
                    currentWaypoint++;
                }
                else
                {
                    reachedEndOfPath = true;
                    _canMove = false;
                    break;
                }
            }
            else
            {
                break;
            }
        }
        Vector3 dir = (path.vectorPath[currentWaypoint] - transform.position).normalized;
        velocity = dir * speed ;
        
        if (_canMove)
        {
        transform.position += velocity * Time.deltaTime;
            isReached = false;
        }


    }
   public Vector2 GetCurrentVelocity()
    {
        return velocity.normalized;
    }

   public bool HasReachedToDestination()
    {
        return isReached;
    }

    IEnumerator DedectEnemy()
    {
        while (_canDedectEnemy)
        {
            seeker.StartPath(transform.position, characterPathfinder.GetClosestTargetPosition(), OnPathComplete);
            yield return new WaitForSeconds(.2f);

        }
    }

    public void StartMovement()
    {
        _canDedectEnemy = true;
        StartCoroutine(DedectEnemy());
    }

    public void StopMovement()
    {
        isReached = true;
        _canDedectEnemy = false;
        _canMove = false;

    }



}