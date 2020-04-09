using UnityEngine;
// Note this line, if it is left out, the script won't know that the class 'Path' exists and it will throw compiler errors
// This line should always be present at the top of scripts which use pathfinding
using Pathfinding;
using Pathfinding.RVO;
using System.Collections;

public class MotorPose : MonoBehaviour
{
    [Header("Initializations")]

    public float speed = 2;

    public float nextWaypointDistance = 3;




    [Header("Debug")]
    [SerializeField]
    [Utils.ReadOnly]
    private int currentWaypoint = 0;

    [SerializeField]
    [Utils.ReadOnly]
    RVOController _rvo;

    [SerializeField]
    [Utils.ReadOnly]
    private bool isReached;

    [SerializeField]
    [Utils.ReadOnly]
    private Vector3 velocity;

    [SerializeField]
    [Utils.ReadOnly]
    public bool _canMove = false;

    [SerializeField]
    [Utils.ReadOnly]
    public bool _canDedectEnemy = false;
    // public Transform targetPosition;
    [SerializeField]
    [Utils.ReadOnly]
    public CharacterPathfinder characterPathfinder;

    [SerializeField]
    [Utils.ReadOnly]
    private Seeker seeker;

    [SerializeField]
    [Utils.ReadOnly]
    public Path path;




    public bool reachedEndOfPath;

    private void Start()
    {
        seeker = GetComponent<Seeker>();
        characterPathfinder = GetComponent<CharacterPathfinder>();
        _rvo = GetComponent<RVOController>();
    }

    public void OnPathComplete(Path p)
    {

        if (p.error)//P errrorsa return edilecek
        {
            StopMovement();
            return;
        }
        path = p;
        currentWaypoint = 0;

        _canMove = true;
        reachedEndOfPath = false;
    }


    private void ProcessNextWaypoint()
    {

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
    }
    private void ProcessMovement()
    {
        transform.position += GetCalculatedRVOPosition();
    }

    private Vector3 GetCalculatedRVOPosition()
    {
        Vector3 dir = (path.vectorPath[currentWaypoint] - transform.position).normalized;
        velocity = dir * speed;
        _rvo.SetTarget(path.vectorPath[currentWaypoint], speed, speed * 1.2f);
        return _rvo.CalculateMovementDelta(transform.position, Time.deltaTime);
    }
       
    private void Update()
    {
        if (path == null)
        {
            return;
        }
        ProcessNextWaypoint();
        ProcessMovement();        
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
           // seeker.StartPath(transform.position, GetClosestTargetPosition(), OnPathComplete);
            yield return new WaitForSeconds(.2f);

        }
    }

    public void StartMovement()
    {
        _canDedectEnemy = true;
        StartCoroutine(DedectEnemy());
        isReached = false;
    }

    public void StopMovement()
    {
        isReached = true;
        _canDedectEnemy = false;
        _canMove = false;

    }



}