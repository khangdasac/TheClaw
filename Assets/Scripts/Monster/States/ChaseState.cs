using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseState : BaseState
{
    private float moveTimer;
    private float losePlayerTimer;
    private float shotTimer;
    private Vector3 lastPlayerPosition;
    public override void Enter()
    {
        
    }

    public override void Exit()
    {
        
    }

    public override void Perform()
    {
        if (monster.CanSeePlayer())
        {
            monster.animator.SetFloat("Speed", 20);
            losePlayerTimer = 0;
            lastPlayerPosition = monster.Player.transform.position + Vector3.up * 1.6f;

            monster.navMeshAgent.speed = 20;
            monster.Agent.SetDestination(lastPlayerPosition);

        }
        else
        {
            monster.animator.SetFloat("Speed", 0);
            losePlayerTimer += Time.deltaTime;
            if (losePlayerTimer > 8)
            {
                //Change to search state
                stateMachine.ChangeState(new PatrolState());
            }
        }
    }



}
