using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class KillPlayerState : BaseState
{
    private bool isPlayed;
    private float deltaTime;
    private Animator continueAnimator;
    public override void Enter()
    {
        isPlayed = true;
        deltaTime = 0;
        continueAnimator = monster.gameOveContinueUI.GetComponent<Animator>();
    }

    public override void Exit()
    {
        
    }

    public override void Perform()
    {

        PlayerGameplay.Instance.isGameOver = true;
        GameManager.Instance.SaveGame();
        monster.animator.SetBool("isGameOver", PlayerGameplay.Instance.isGameOver);
        playerCamera.transform.LookAt(monster.transform.position + Vector3.up * 6f);

        monster.transform.position = monster.transform.position + Vector3.down * 3f;

        monster.Agent.isStopped = true;
        monster.Agent.velocity = Vector3.zero;

        

        deltaTime += Time.deltaTime;

        if(deltaTime > 1.5f)
        {
            if (!monster.gameOverUI.active)
                monster.gameOverUI.SetActive(true);
        }

        if(deltaTime > 2.5f)
        {
            if (!continueAnimator.GetBool("isShowContinue"))
                continueAnimator.SetBool("isShowContinue", true);
        }

        if (isPlayed)
        {
            monster.PlayMonsterShoutEnd();

            isPlayed = false;
        }

    }
}
