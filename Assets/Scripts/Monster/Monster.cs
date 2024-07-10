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
    public GameObject Player { get => player;}

    public Path path;

    [Header("Sight Values")]
    public float sightDistance = 20f;
    public float fieldOfView = 85f;
    public float eyeHeight;

    [Header("Weapon Values")]
    public Transform gunBarrel;
    [Range(0.1f, 10f)]
    public float fireRate;
    [SerializeField]
    private string currentState;

    [Header("Animation")]
    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        stateMachine = GetComponent<StateMachine>();
        agent = GetComponent<NavMeshAgent>();
        stateMachine.Initialise();
        player = GameObject.FindGameObjectWithTag("Player");

    }

    // Update is called once per frame
    void Update()
    {
        CanSeePlayer();
        currentState = stateMachine.activeState.ToString();
    }

    public bool CanSeePlayer()
    {
        if(Player != null)
        {
            if(Vector3.Distance(transform.position, Player.transform.position) < sightDistance)
            {
                Vector3 targetDirection = Player.transform.position - transform.position - Vector3.up * eyeHeight;
                float angelToPlayer = Vector3.Angle(targetDirection, transform.forward);
                if(angelToPlayer >= - fieldOfView && angelToPlayer <= fieldOfView) 
                {
                    Ray ray = new Ray(transform.position + Vector3.up * eyeHeight, targetDirection);
                    RaycastHit hitInfo = new RaycastHit();
                    if(Physics.Raycast(ray,out hitInfo, sightDistance))
                    {
                        if(hitInfo.transform.gameObject == Player)
                        {
                            Debug.DrawRay(ray.origin, ray.direction * sightDistance);
                            return true;
                        }
                    }
                }
            }
        }
        return false;
    }
}
