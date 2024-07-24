using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spikeKill : MonoBehaviour
{
    public PlayerHealthScript healthScript;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("player"))
        {
            healthScript.playerHealth -= 9000000;
        }
    }
}
