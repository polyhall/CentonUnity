using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    // Varialbes
    public float mouseSensitivity = 5f;
    public Transform playerBody;
    public PhotonView photonView;

    //--
    private float xRotation;


    // Methods
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        if (!photonView.IsMine) {return;}

        float mouseX = Input.GetAxisRaw("Mouse X") * (mouseSensitivity * 100f * Time.deltaTime);
        float mouseY = Input.GetAxisRaw("Mouse Y") * (mouseSensitivity * 100f * Time.deltaTime);

        //--
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        //--
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        playerBody.Rotate(Vector3.up, mouseX);
    }
}
