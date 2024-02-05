using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;

public class Flashlight : MonoBehaviour
{
    // Variables
    public PhotonView photonView;
    public GameObject flashlight;

    // Methods
    void Update()
    {
        if (!photonView.IsMine) {return;}

        //--
        if (Input.GetKeyDown(KeyCode.F))
        {
            //ToggleFlashlight();
            photonView.RPC("ToggleFlashlight", RpcTarget.All);
        }
    }
    
    // RPC Methods
    [PunRPC]
    public void ToggleFlashlight()
    {
        flashlight.SetActive(!flashlight.activeSelf);
    }
}
