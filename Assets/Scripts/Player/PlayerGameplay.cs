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

    private bool hasTriggeredWinEvent;

    public static PlayerGameplay Instance
    {
        get => instance;
        set => instance = value;
    }

    private void Awake()
    {
        Instance = this;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("LineWinGame"))
        {
            isWinGame = true;
        }
    }

    private void Update()
    {
        if (!isWinGame)
            return;

        gameWinBackground.SetActive(true);

        Animator gameWinAnimator = gameWin.GetComponent<Animator>();
        gameWinAnimator.SetBool("isShowContinue", true);

        monster.Agent.isStopped = true;
        monster.Agent.velocity = Vector3.zero;

        if (!hasTriggeredWinEvent)
        {
            hasTriggeredWinEvent = true;
            winGameEvent.Invoke();
        }
    }

    public bool IsContinue()
    {
        return !isGameOver && !isWinGame;
    }
}