using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Monster : MonoBehaviour
{
    private StateMachine stateMachine;
    private NavMeshAgent agent;
    private GameObject player;
    public NavMeshAgent Agent { get => agent; }
    public GameObject Player { get => player; }

    public Path path;

    [Header("Sight Values")]
    public float sightDistance = 30f;
    public float fieldOfView = 80f;
    public float eyeHeight;

    [SerializeField]
    private string currentState;

    [Header("Monster's")]
    public Animator animator;
    public NavMeshAgent navMeshAgent;

    [Header("Footstep")]
    public AudioClip monsterFootStep;
    private AudioSource monsterAudioSource;

    [Header("Shout")]
    public AudioClip monsterShoutClip;
    public AudioClip monsterShoutEndClip;

    [Header("Game over")]
    public GameObject gameOverUI;
    public GameObject gameOveContinueUI;



    // Start is called before the first frame update
    void Start()
    {
        stateMachine = GetComponent<StateMachine>();
        agent = GetComponent<NavMeshAgent>();
        stateMachine.Initialise();
        player = GameObject.FindGameObjectWithTag("Player");
        monsterAudioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        CanSeePlayer();
        currentState = stateMachine.activeState.ToString();
    }

    public bool CanSeePlayer()
    {
        if (Player != null)
        {

            if (Vector3.Distance(transform.position, Player.transform.position + Vector3.up * 2f) < sightDistance)
            {

                Vector3 targetDirection = Player.transform.position + Vector3.up * 2f - (transform.position + Vector3.up * eyeHeight);
                float angelToPlayer = Vector3.Angle(targetDirection, transform.forward);


                if (angelToPlayer >= -fieldOfView && angelToPlayer <= fieldOfView)
                {

                    Ray ray = new Ray(transform.position + Vector3.up * eyeHeight, targetDirection);
                    RaycastHit hitInfo = new RaycastHit();
                    Debug.DrawRay(ray.origin, ray.direction * sightDistance);

                    if (Physics.Raycast(ray, out hitInfo, sightDistance))
                    {
                        if (hitInfo.transform.gameObject == Player)
                        {
                            //Debug.Log("Monster seen player");
                            monsterAudioSource.PlayOneShot(monsterShoutClip, 0.1f);
                            return true;
                        }
                    }
                }
            }
        }
        //Debug.Log("Monster don't see player");

        return false;
    }

    public void PlayFootStep()
    {
        float distance = Vector3.Distance(transform.position, Player.transform.position + Vector3.up * 2f);
        float volumeScale = distance < 5 ? 1 : (distance < 80 ? 5/distance : 0);
        monsterAudioSource.PlayOneShot(monsterFootStep, volumeScale);
    }

    public void PlayMonsterShoutEnd()
    {
        monsterAudioSource.PlayOneShot(monsterShoutEndClip, 0.5f);
    }
}
