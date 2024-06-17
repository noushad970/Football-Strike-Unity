using Unity.Netcode;
using Unity.Netcode.Components;
using UnityEngine;


public class MoveMent : NetworkBehaviour
{
    public float speed = 6.0f; // Movement speed
    public float gravity = -9.8f; // Gravity force
    private Vector3 moveDirection = Vector3.zero;
    private CharacterController controller;
    Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
        // Get the CharacterController component attached to the character
        controller = GetComponent<CharacterController>();
    }
    
    void Update()
    {
        // Check if the character is grounded
        if(!IsOwner)return;
        movement();
    }
    
   
    void movement()
    {
        float moveHorizontal = Input.GetAxis("Horizontal"); // A/D or Left/Right arrow keys
        float moveVertical = Input.GetAxis("Vertical");
        if (controller.isGrounded)
        {
            // Get input from the keyboard
            // W/S or Up/Down arrow keys
            if (Mathf.Abs(moveVertical + moveVertical) > 0)
            {
                anim.SetBool("IsWalking", true);
            }
            else
                anim.SetBool("IsWalking", false);
            // Set the movement direction based on input
            moveDirection = new Vector3(moveHorizontal, 0.0f, moveVertical);
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection *= speed;
        }

        // Apply gravity to the movement direction
        moveDirection.y += gravity * Time.deltaTime;

        // Move the character controller
        controller.Move(moveDirection * Time.deltaTime);
    }
}
