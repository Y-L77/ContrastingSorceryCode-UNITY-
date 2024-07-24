using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shadowDestroy : MonoBehaviour
{
    public GameObject shadow;
    public PlayerMovement playerMovement;
    public AudioSource explosion;
    public AudioSource bombHiss;
    public GameObject deathParticles;


    void Start()
    {
        GameObject playerObject = GameObject.FindWithTag("player");
        if (playerObject != null)
        {
            playerMovement = playerObject.GetComponent<PlayerMovement>();
        }
        else
        {
            Debug.LogError("Player object with tag 'player' not found.");
        }
        if (playerMovement.facingRight)
        {
            shadow.transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else
        {
            shadow.transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        bombHiss.Play();
        StartCoroutine(ScaleShadow());
        StartCoroutine(Explode());
    }
    IEnumerator ScaleShadow()
    {
        for (int i = 0; i < 6; i++)
        {
            shadow.transform.localScale += new Vector3(0.05f, 0.05f, 0);
            yield return new WaitForSeconds(0.2f);
        }
    }

    IEnumerator Explode()
    {
        yield return new WaitForSeconds(1.5f);
        explosion.Play();
        Instantiate(deathParticles, transform.position, Quaternion.identity);

    }
}
