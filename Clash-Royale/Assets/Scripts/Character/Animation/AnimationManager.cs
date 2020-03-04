
using Pathfinding;
using UnityEngine;

public class AnimationManager : MonoBehaviour
{
    public Seeker seeker;
    public Transform target;

    int currentWayPoint;
    Pathfinding.Path path;

    Animator anim;
    private void Awake()
    {
        seeker = GetComponent<Seeker>();
        anim = GetComponent<Animator>();
    }

    private void Start()
    {
        seeker.StartPath(transform.position, target.position, onPathCompleted);

    }
    private void Update()
    {
    
    }

    private void FixedUpdate()
    {
        if (path == null)
        {
            return;
        }
        if (currentWayPoint >= path.vectorPath.Count)
        {
            return;
        }
        Vector3 dir = ( transform.position- path.vectorPath[currentWayPoint] ).normalized;
        //Report the path using the delegate
        anim.SetFloat("InputX",dir.x);


        anim.SetFloat("InputY",dir.y);
    }
    void onPathCompleted(Pathfinding.Path p)
    {
        if (!p.error)
        {
            path = p;
            currentWayPoint = 0;
        }
        else
        {
            Debug.Log(p.error);
        }
    }

}
