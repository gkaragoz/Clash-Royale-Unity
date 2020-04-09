using UnityEngine;
// Note this line, if it is left out, the script won't know that the class 'Path' exists and it will throw compiler errors
// This line should always be present at the top of scripts which use pathfinding
using Pathfinding;
using Pathfinding.RVO;
using System.Collections;

public class CharacterMotor : MonoBehaviour
{
    [Header("Initializations")]

    public float speed = 2;

    public float nextWaypointDistance = 3;

    private float _myPlayerId;



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


    bool canAttack;

    [SerializeField]
    [Utils.ReadOnly]
    Transform _currentEnemy;
    [SerializeField]
    [Utils.ReadOnly]
    public bool _canDedectEnemy = false;
    // public Transform targetPosition;
    [SerializeField]
    [Utils.ReadOnly]
    public CharacterPathfinder characterPathfinder;
    [SerializeField]
    [Utils.ReadOnly]
    public Character _character;
    [SerializeField]
    [Utils.ReadOnly]
    private Seeker seeker;

    [SerializeField]
    [Utils.ReadOnly]
    public Path path;



    private void Start()
    {
        _myPlayerId = GetComponent<LivingEntity>().GetPlayerId();
        seeker = GetComponent<Seeker>();
        _character = GetComponent<Character>();
        characterPathfinder = GetComponent<CharacterPathfinder>();
        _rvo = GetComponent<RVOController>();
        isReached = true;
    }

    public void OnPathComplete(Path p)
    {
        if (p.error)
        {
            StopMovement();
            return;
        }
        path = p;
        currentWaypoint = 0;
        _canMove = true;
        isReached = false;

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
                    isReached = true;
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
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartMovement();
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            StopMovement();
        }
        if (_currentEnemy!=null)
        {
            MoveAndAttackToEnemy();
        }
        else
        {
            StartMovement();
        }

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
        Vector3 pos;
        while (_canDedectEnemy)
        {
            //
            _currentEnemy = characterPathfinder.GetEnemyInRange();

            if (_currentEnemy == null)
            {
                pos=characterPathfinder.GetClosestMovementPoint().position + Vector3.up * .9f * _myPlayerId;
                seeker.StartPath(transform.position,pos, OnPathComplete);

            }
            else
            {

                pos=characterPathfinder.GetEnemyInRange().position;            
                seeker.StartPath(transform.position, pos, OnPathComplete);
            }

            yield return new WaitForSeconds(.1f);

        }
    }

    public void StartMovement()
    {
        if (_canDedectEnemy==false)
        {
            _canDedectEnemy = true;
             StartCoroutine(DedectEnemy());
        }
    }

    public void StopMovement()
    {
        _canMove = false;
        _canDedectEnemy = false;
        isReached = true;
    }
           


    public Vector3 GetClosestTargetPosition()
    {
        _currentEnemy = characterPathfinder.GetEnemyInRange();

        if (_currentEnemy == null)
        {
            return (characterPathfinder.GetClosestMovementPoint().position + Vector3.up * .9f * _myPlayerId);

        }
        else
        {
            return characterPathfinder.GetEnemyInRange().position;
        }
    }


    public void MoveAndAttackToEnemy()
    {
        if (Vector3.Distance(transform.position, _currentEnemy.position) < _character.AttackRange)
        {
           StartAttack(_currentEnemy.GetComponent<LivingEntity>());
           StopMovement();                        
        }
        else
        {
           canAttack = false;
            _currentEnemy = null;
           StartMovement();
        }

    }




    public void StartAttack(LivingEntity target)
    {
        if (canAttack == false)
        {
            canAttack = true;
            StartCoroutine(AttackToEnemy(target.GetComponent<ICanDamageable>()));
        }
        else
        {
            if (!target.gameObject.activeSelf)
            {
                canAttack = false;
                _currentEnemy = null;
            }
        }
    }

    IEnumerator AttackToEnemy(ICanDamageable target)
    {
        while (canAttack)
        {
            yield return new WaitForSeconds(_character.AttackSpeed);
            if (target != null)
            {
                target.TakeDamage(_character.AttackDamage);
            }
           
        }
    
    }





}