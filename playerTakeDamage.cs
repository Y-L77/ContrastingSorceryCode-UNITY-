using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerTakeDamage : MonoBehaviour
{
    public PolygonCollider2D mudHand;
    public PlayerHealthScript healthScript;
    public AudioSource reaperSpellSFX;
    public AudioSource hurtSFX;

    private Coroutine damageCoroutine;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.name == "Mud_Hand(Clone)")//to see the name of the collider name you can use this for debugging |  Debug.Log("Collision detected with: " + collision.collider.name);
        {
            // Start the damage coroutine with a specified damage value if it's not already running
            if (damageCoroutine == null)
            {
                healthScript.playerHealth -= 5; //on hit it does a deafult value and then after that it continue to do damage after 2 sceonds. you can not be in a collision with 2 enemies and get damaged twice the couroutine only accounts for one enemy
                damageCoroutine = StartCoroutine(TakeDamageOverTime(5)); // Passing 5 as damage value
            }
        }
        if (collision.collider.name == "skeleton(Clone)")
        {
            if (damageCoroutine == null)
            {
                healthScript.playerHealth -= 20; //on hit it does a deafult value and then after that it continue to do damage after 2 sceonds. you can not be in a collision with 2 enemies and get damaged twice the couroutine only accounts for one enemy
                damageCoroutine = StartCoroutine(TakeDamageOverTime(20));
            }
        }
        if (collision.collider.name == "reaper(Clone)")
        {
            if (damageCoroutine == null)
            {
                healthScript.playerHealth -= 50; //on hit it does a deafult value and then after that it continue to do damage after 2 sceonds. you can not be in a collision with 2 enemies and get damaged twice the couroutine only accounts for one enemy
                damageCoroutine = StartCoroutine(TakeDamageOverTime(50));
            }
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.name == "Mud_Hand(Clone)" && damageCoroutine != null)
        {
            // Stop the damage coroutine when exiting collision
            StopCoroutine(damageCoroutine);
            damageCoroutine = null;
            hurtSFX.Play();
        }
        if (collision.collider.name == "skeleton(Clone)" && damageCoroutine != null)
        {
            StopCoroutine(damageCoroutine);
            damageCoroutine = null;
            hurtSFX.Play();
        }
        if (collision.collider.name == "reaper(Clone)" && damageCoroutine != null)
        {
            StopCoroutine(damageCoroutine);
            damageCoroutine = null;
            hurtSFX.Play();
        }
    }

    private IEnumerator TakeDamageOverTime(int damageAmount)
    {
        while (true) // Infinite loop until stopped
        {
            yield return new WaitForSeconds(2f); // Wait for 2 seconds
            healthScript.playerHealth -= damageAmount; // Damage the player
            hurtSFX.Play();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) //ON TRIGGER METHOD, THIS IS WHEN PLAYER GET HIT BY SPELLS
    {
        if (collision.CompareTag("reaper_spell"))
        {
            reaperSpellSFX.Play();
            healthScript.playerHealth -= 30;
        }
    }
}

