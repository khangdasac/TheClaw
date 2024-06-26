using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMotor : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 playerVelocity;
    private bool isGrounded;

    [Header("Player's parameters")]
    public float speed = 10f;
    public float highSpeed = 20f;
    public float lowSpeed = 5f;
    public float normalSpeed = 10f;
    public float jumpHeight = 1.5f;

    [Header ("Specifications")]
    public float gavity = -9.8f;
    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = controller.isGrounded;
    }

    public void ProcessMove(Vector3 move)
    {
        //Movement
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
            playerVelocity.y = Mathf.Sqrt(-2.0f * jumpHeight * gavity);
        }
    }
}
