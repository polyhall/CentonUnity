using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;

public class Flashlight : MonoBehaviour
{
    public PhotonView photonView;
    public GameObject flashlight;

    // Methods
    void Update()
    {
        if (!photonView.IsMine) {return;}

        if (Input.GetKeyDown(KeyCode.F))
        {
            photonView.RPC("ToggleFlashlight", RpcTarget.All);
        }
    }

    [PunRPC]
    public void ToggleFlashlight()
    {
        flashlight.SetActive(!flashlight.activeSelf);
    }
}
