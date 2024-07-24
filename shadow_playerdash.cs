using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shadow_playerdash : MonoBehaviour
{
    public PlayerMovement playerMovement;
    public GameObject player;
    void Start()
    {
        GameObject playerObject = GameObject.FindWithTag("player");
        if (playerObject != null)
        {
            playerMovement = playerObject.GetComponent<PlayerMovement>();
            player = playerObject;
        }
        else
        {
            Debug.LogError("Player object with tag 'player' not found.");
        }
        StartCoroutine(playerShadowDash());
    }

    IEnumerator playerShadowDash()
    {
        for (int i = 0; i < 5; i++)
        {
            if (playerMovement.facingRight)
            {
                player.transform.position += new Vector3(0.4f, 0.2f, 0);
            }
            else
            {
                player.transform.position += new Vector3(-0.4f, 0.2f, 0);
            }
            yield return new WaitForSeconds(0.05f);
        }
    }

}
