using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
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
    public float jumpPower = 5;

    //--
    private Vector3 inputDirection;
    private Vector3 moveDirection;
    private Vector3 velocity;
    private CharacterController controller;
    private PhotonView photonView;
    private float moveSpeed;
    private float acceleration;
    private float height;
    private bool crouching = false;
    private bool noClipping = false;

    // Methods
    void Start()
    {
        photonView = GetComponent<PhotonView>();

        if (!photonView.IsMine) {return;}

        controller = GetComponent<CharacterController>();
        moveSpeed = walkSpeed;
    }

    void Update()
    {
        if (!photonView.IsMine) {return;}

        inputDirection = new Vector3(Input.GetAxisRaw("Horizontal"), 0f, Input.GetAxisRaw("Vertical"));
        inputDirection.Normalize();
    
        //--
        HandleMovement();
    }


    void HandleMovement()
    {
        //--
        Vector3 wishDirection = transform.TransformDirection(inputDirection);

        //--
        if (controller.isGrounded)
        {
            velocity.y = -1f;
            acceleration = groundAccel;

            //--
            if (Input.GetKeyDown(KeyCode.Space))
                velocity.y = jumpPower;
        }
        else
        {
            velocity.y -= gravity * 2f * Time.deltaTime;
            acceleration = airAccel;
        }

        //--
        crouching = Input.GetKey(KeyCode.LeftControl);
        
        if (crouching)
        {
            height = crouchHeight;
            moveSpeed = crouchSpeed;
        }
        else
        {
            height = normalHeight;
            moveSpeed = walkSpeed;
        }

        controller.height = Mathf.Lerp(controller.height, height, acceleration * Time.deltaTime);

        //--
        moveDirection = Vector3.Lerp(moveDirection, wishDirection, acceleration * Time.deltaTime);

        //--
        controller.Move(moveDirection * moveSpeed * Time.deltaTime);
        controller.Move(velocity * Time.deltaTime);
    }
}
