using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    // Variables
    private PhotonView photonView;
    public int health;
    
    // Methods
    [PunRPC]
    public void TakeDamage(int damageAmount)
    {
        health -= damageAmount;

        if (health <= 0)
        {
            if (photonView.IsMine)
                return;

            Destroy(gameObject);
        }
    }
}
