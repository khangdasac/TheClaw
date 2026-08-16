using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerMotor : MonoBehaviour
{
    public CharacterController controller;
    private Vector3 playerVelocity;
    private bool isGrounded;
    private bool isGrounding;

    [Header("Player's parameters")]
    public float speed = 10f;
    public float highSpeed = 22f;
    public float lowSpeed = 10f;
    public float normalSpeed = 10f;
    public float jumpHeight = 1.2f;

    [Header("Specifications")]
    public float gavity = -9.8f;

    [Header("Animator")]
    public Animator playerAnimator;
    // Start is called before the first frame update
    [Header("Audio")]
    private AudioSource playerAudioSource;
    public AudioClip footStepClip;
    public AudioClip groundingClip;
    private float deltaTime;
    private float stepCycle;


    void Start()
    {
        controller = GetComponent<CharacterController>();
        playerAudioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = controller.isGrounded;
        Grounding();
    }

    public void ProcessMove(Vector3 move)
    {
        //Movement
        if (move.Equals(Vector3.zero))
        {
            playerAnimator.SetBool("isMovement", false);
        }
        else
        {
            playerAnimator.SetBool("isMovement", true);
        }



        playerAnimator.SetFloat("moveX", move.x);
        playerAnimator.SetFloat("moveY", move.y);
        Vector3 moveDirection = Vector3.zero;
        moveDirection.x = move.x;
        moveDirection.z = move.y;
        controller.Move(transform.TransformDirection(moveDirection) * speed * Time.deltaTime);



        //Jump
        playerVelocity.y += gavity * Time.deltaTime;
        if (isGrounded && playerVelocity.y < 0)
        {
            playerVelocity.y = -2f;
        }

        controller.Move(playerVelocity * Time.deltaTime);


    }

    public void Jump()
    {
        if (isGrounded)
        {
            isGrounding = true;
            playerAnimator.SetTrigger("isJump");
            playerVelocity.y = Mathf.Sqrt(-2.0f * jumpHeight * gavity);
        }
    }

    public void Grounding()
    {
        if (isGrounding && isGrounded && playerVelocity.y < 0)
        {
            playerAudioSource.PlayOneShot(groundingClip, 0.2f);
            isGrounding = false;    
        }
    }

    public void FootStepSound(Vector3 move)
    {
        if (speed == normalSpeed)
        {
            stepCycle = 0.5f;
        }
        else if (speed == highSpeed)
        {
            stepCycle = 0.3f;
        }
        else if(speed == lowSpeed)
        {
            stepCycle = 0.8f;
        }

        if (!move.Equals(Vector3.zero) && isGrounded)
        {
            deltaTime += Time.deltaTime;
            if (deltaTime > stepCycle)
            {
                playerAudioSource.PlayOneShot(footStepClip, 0.2f);
                deltaTime = 0;
            }
        }
        else
        {
            deltaTime = 0;
        }
    }



}
