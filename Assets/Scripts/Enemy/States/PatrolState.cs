using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolState : BaseState
{

    public int waypointIndex;
    public float waitTime = 3f;
    private float deltaTime;
    public override void Enter()
    {
        
    }

    public override void Exit()
    {
        
    }

    public override void Perform()
    {
        PatrolCycle();
    }

    public void PatrolCycle()
    {
        if(enemy.Agent.remainingDistance < 0.2f){
            deltaTime += Time.deltaTime;
            if(deltaTime > waitTime)
            {
                if (waypointIndex < enemy.path.waypoints.Count - 1)
                {
                    waypointIndex++;
                }
                else
                {
                    waypointIndex = 0;
                }
                enemy.Agent.SetDestination(enemy.path.waypoints[waypointIndex].position);
                deltaTime = 0;
            }


        }


    }
}
