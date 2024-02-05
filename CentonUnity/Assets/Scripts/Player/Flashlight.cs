using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;

public class Flashlight : MonoBehaviour
{
    public PhotonView photonView;
    private Light flashlight;
    private bool active = false;


    // Methods
    void Start()
    {
        flashlight = GetComponent<Light>();
    }

    void Update()
    {
        if (!photonView.IsMine) {return;}

        if (Input.GetKeyDown(KeyCode.F))
        {
            flashlight.enabled = !flashlight.enabled;
        }
    }
}
