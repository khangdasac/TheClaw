using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class KillPlayerState : BaseState
{
    public override void Enter()
    {
        
    }

    public override void Exit()
    {
        
    }

    public override void Perform()
    {
        PlayerGameplay.Instance.isGameOver = true;
        monster.animator.SetBool("isGameOver", PlayerGameplay.Instance.isGameOver);
        playerCamera.transform.LookAt(monster.transform.position + Vector3.up * 6f);
        headMonster.transform.LookAt(playerCamera.transform);
        monster.transform.position = monster.transform.position + Vector3.down * 3f;
        Debug.Log("monster:" + monster.transform.position + Vector3.up * 2f);
        Debug.Log("camera:" + playerCamera.transform.position);
    }
}
