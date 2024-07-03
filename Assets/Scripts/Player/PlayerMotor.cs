using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerMotor : MonoBehaviour
{
    public CharacterController controller;
    private Vector3 playerVelocity;
    private bool isGrounded;

    [Header("Player's parameters")]
    public float speed = 10f;
    public float highSpeed = 20f;
    public float lowSpeed = 5f;
    public float normalSpeed = 10f;
    public float jumpHeight = 1.2f;

    [Header ("Specifications")]
    public float gavity = -9.8f;

    [Header("Animator")]
    public PlayerAnimator playerAnimator;
    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        playerAnimator = GetComponent<PlayerAnimator>();
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = controller.isGrounded;
        
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
            playerAnimator.SetTrigger("isJump");
            playerVelocity.y = Mathf.Sqrt(-2.0f * jumpHeight * gavity);
        }
    }

}
