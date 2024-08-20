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
        if (monster.CanSeePlayer())
        {
            stateMachine.ChangeState(new ChaseState());
        }
    }

    public void PatrolCycle()
    {
        if(monster.Agent.remainingDistance < 0.2f){
            deltaTime += Time.deltaTime;
            if(deltaTime > waitTime)
            {
                waypointIndex = Random.Range(0, monster.path.waypoints.Count);
                if (waypointIndex < monster.path.waypoints.Count - 1)
                {
                    waypointIndex++;
                }
                else
                {
                    waypointIndex = 0;
                }
                monster.Agent.SetDestination(monster.path.waypoints[waypointIndex].position);
                deltaTime = 0;
            }

            monster.animator.SetFloat("Speed", 0);

        }
        else
        {
            monster.animator.SetFloat("Speed", 10);

        }


    }
}
