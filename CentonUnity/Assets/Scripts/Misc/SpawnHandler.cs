using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

public class SpawnHandler : MonoBehaviour
{
    // Variables
    public GameObject cubePrefab;
    private PhotonView photonView;

    // Methods
    void Start()
    {
        photonView = GetComponent<PhotonView>();
    }

    void Update()
    {
        if (!photonView.IsMine) {return;}

        //--
        if (Input.GetKeyDown(KeyCode.G))
        {
            photonView.RPC("SpawnCube", RpcTarget.All);
        }
    }

    // RPC Methods
    [PunRPC]
    public void SpawnCube()
    {
        GameObject newCube = PhotonNetwork.Instantiate(cubePrefab.name, transform.position, Quaternion.identity);
    }
}
