using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Variables
    public float walkSpeed = 5;
    public float crouchSpeed = 2;
    public float normalHeight = 1;
    public float crouchHeight = 0.5f;
    public float groundAccel = 10;
    public float airAccel = 2;
    public float gravity = 9.81f;

    //--
    private Vector3 inputDirection;
    private Vector3 moveDirection;
    private Vector3 velocity;
    private CharacterController controller;
    private float moveSpeed;
    private float acceleration;


    // Methods
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        inputDirection = new Vector3(Input.GetAxisRaw("Horizontal"), 0f, Input.GetAxisRaw("Vertical"));
        inputDirection.Normalize();
    
        //--
        moveDirection = transform.TransformDirection(inputDirection);

        //--
        if (controller.isGrounded)
        {
            velocity.y = -1f;
            acceleration = groundAccel;
        }
        else
        {
            velocity.y -= gravity * 2f * Time.deltaTime;
            acceleration = airAccel;
        }

        controller.Move(moveDirection * moveSpeed * Time.deltaTime);
        controller.Move(velocity);
    }
}
