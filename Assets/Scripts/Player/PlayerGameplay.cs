using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerGameplay : MonoBehaviour
{
    private static PlayerGameplay instance;
    public bool isGameOver;
    public bool isWinGame;
    public GameObject gameWinBackground;
    public GameObject gameWin;
    public Monster monster;

    public UnityEvent winGameEvent;


    public static PlayerGameplay Instance { get => instance; set => instance = value; }

    void Awake()
    {
        Instance = this;
    }

    private void OnTriggerEnter(Collider other)
    {
        isWinGame = other.CompareTag("LineWinGame");
    }

    private void Update()
    {
        if (isWinGame)
        {
            gameWinBackground.SetActive(true);
            Animator gameWinAnimator = gameWin.GetComponent<Animator>();
            gameWinAnimator.SetBool("isShowContinue", true);

            monster.Agent.isStopped = true;
            monster.Agent.velocity = Vector3.zero;
            winGameEvent.Invoke();
        }
    }

    public bool IsContinue()
    {
        return !isGameOver && !isWinGame;
    }
}
