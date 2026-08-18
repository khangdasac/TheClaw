using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseState : BaseState
{
    private float moveTimer;
    private float losePlayerTimer;
    private float shotTimer;
    private Vector3 lastPlayerPosition;
    private static float waitTimer = 4f;
    private static float speedChase = 18f;
    public override void Enter()
    {
        
    }

    public override void Exit()
    {
        
    }

    public override void Perform()
    {
        if(Vector3.Distance(monster.transform.position, monster.Player.transform.position) > 5f)
        {
            if (monster.CanSeePlayer())
            {
                monster.animator.SetFloat("Speed", 20);
                losePlayerTimer = 0;
                lastPlayerPosition = monster.Player.transform.position + Vector3.up * 2f;

                monster.navMeshAgent.speed = speedChase;
                monster.Agent.SetDestination(lastPlayerPosition);

            }
            else
            {
                monster.animator.SetFloat("Speed", 0);
                losePlayerTimer += Time.deltaTime;
                if (losePlayerTimer > waitTimer)
                {
                    //Change to search state
                    stateMachine.ChangeState(new PatrolState());
                }
            }
        }
        else
        {
            stateMachine.ChangeState(new KillPlayerState());
        }

    }



}
