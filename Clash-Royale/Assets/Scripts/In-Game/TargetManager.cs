using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;


public class TargetManager : MonoBehaviour
{
    [SerializeField]
    private Transform[] targets;



    private void Update()
    {
        
    }


    public void GiveMeTarget(Transform myPosition )
    {
       

        Transform target=null;
        float currentDistance=5000;
        for (int ii = 0; ii < targets.Length; ii++)
        {
            float distance = Vector2.Distance(myPosition.position, targets[ii].position);

            if (distance<currentDistance&&myPosition.position.y<targets[ii].position.y)
            {
                currentDistance = distance;
                //Ai Destination
                target = targets[ii];
                //Ai Dest Setter Script
              

            }
        }
        MoveAgentToTarget(myPosition,target);


    }


    public void MoveAgentToTarget(Transform myPosition,Transform target)
    {
        var myTarget = myPosition.gameObject.GetComponent<AIDestinationSetter>();
        myTarget.target = target;
    }

}
