using System.Collections;
using System.Collections.Generic;
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
        camera.transform.LookAt(monster.transform.position + Vector3.up * 2f);
    }
}
