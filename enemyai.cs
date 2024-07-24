using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class enemyai : MonoBehaviour 

    //in this script you can just copy all of these contents because it will be true for almost every enemy.
{
    public float health = 100;
    public int giveHealth = 5; //when killed the enemy will either give you 5 hp or 25 cash
    public int giveMoney = 25;
    public playerCoinsScript coinScript;
    public PlayerHealthScript healthScript;
    public spellCastingScript_UI1 spellCastingScript; //holds all the spell data
    public GameObject deathParticle;
    public TMP_Text enemyKilledText;
    public GameObject enemyKilledGameObject;
    public GameObject player;
    public Rigidbody2D enemyRB;
    public float distanceChecker;
    public AudioSource enemyKilledSFX;
    public AudioSource enemyHitSFX;
    private Vector3 originalPosition;




    public void Start()//assigning all the references
    {
        originalPosition = transform.position;

        GameObject gameLogic = GameObject.FindWithTag("gamelogicscripts");
        if (gameLogic != null)
        {
            coinScript = gameLogic.GetComponent<playerCoinsScript>();
            healthScript = gameLogic.GetComponent<PlayerHealthScript>();
        }
        else
        {
            Debug.LogError("GameLogic object with tag 'gamelogicscripts' not found.");
        }

        GameObject playerObject = GameObject.FindWithTag("player");
        if (playerObject != null)
        {
            spellCastingScript = playerObject.GetComponent<spellCastingScript_UI1>();
            player = playerObject; // Correctly assigning the player reference
        }
        else
        {
            Debug.LogError("Player object with tag 'player' not found.");
        }

        enemyKilledGameObject = GameObject.FindWithTag("text");
        if (enemyKilledGameObject != null)
        {
            enemyKilledText = enemyKilledGameObject.GetComponent<TMP_Text>();
        }
        else
        {
            Debug.LogError("Enemy killed text object with tag 'text' not found.");
        }

        // Additional debug to confirm all references are set
        if (coinScript != null) Debug.Log("Coin script assigned successfully.");
        if (healthScript != null) Debug.Log("Health script assigned successfully.");
        if (spellCastingScript != null) Debug.Log("Spell casting script assigned successfully.");
        if (enemyKilledText != null) Debug.Log("Enemy killed text assigned successfully.");
        if (player != null) Debug.Log("Player assigned successfully.");

    }
    public void TakeDamage(float damage)
    {
        enemyHitSFX.Play();
        health -= damage;
        if (health <= 0)
        {
            health = 100000000;
            Die();
        }
    }

    private void Update() //add enemy ai logic here e.g moving towards player, casting spells.
    {
        if (Vector2.Distance(transform.position, player.transform.position) <= distanceChecker) //the distanceChecker variable is how many units the enemy will chase the player
        {
            if (player.transform.position.x >= transform.gameObject.transform.position.x)
            {
                enemyRB.velocity = new Vector2(2f, enemyRB.velocity.y);
                gameObject.transform.rotation = Quaternion.Euler(0, 0, 0);
            }
            else
            {
                enemyRB.velocity = new Vector2(-2f, enemyRB.velocity.y);
                gameObject.transform.rotation = Quaternion.Euler(0, 180, 0);
            }
        }
        else
        {
            // Stop the enemy if the player is out of range
            enemyRB.velocity = new Vector2(0, enemyRB.velocity.y);
        }


        //this will teleport back the mob if it wanders off too far
        if (Vector3.Distance(transform.position, originalPosition) >= 40f)
        {
            transform.position = originalPosition;
        }

    }

    void Die()
    {
        // Add death logic (e.g., play animation, drop loot)
        enemyKilledSFX.Play();
        enemyKilledText.text = "Enemy killed + " + giveHealth + "HP!";
        enemyKilledGameObject.SetActive(true);
        StartCoroutine(HideEnemyKilledText(1f));
        coinScript.playerCoins += giveMoney;
        healthScript.maxPlayerHealth += giveHealth;
        Instantiate(deathParticle, transform.position, Quaternion.identity);
  
    }
    public IEnumerator HideEnemyKilledText(float delay)
    {
        yield return new WaitForSeconds(delay); // Wait for the specified delay
        if (enemyKilledGameObject.activeSelf) // Only hide if it's currently active
        {
            enemyKilledText.text = " "; // Hide the text
            Destroy(gameObject);
        }
        else
        {
            Debug.Log("text is not active");
        }
    }


    private void OnTriggerEnter2D(Collider2D collision) //detects what spell enters the enemy and then relates it to the corresponding spell damage attribute
    {
        if (collision.CompareTag("fireball_spell"))
        {
            TakeDamage(spellCastingScript.fireballDamage);
        }
        if (collision.CompareTag("icicle_spell"))
        {
            TakeDamage(spellCastingScript.icicleDamage);
        }
        if (collision.CompareTag("necromancy_spell"))
        {
            TakeDamage(spellCastingScript.necromancyDamage);
        }
        if (collision.CompareTag("dragon_spell"))
        {
            TakeDamage(spellCastingScript.dragonDamage);
        }
        if (collision.CompareTag("shadow_spell"))
        {
            TakeDamage(spellCastingScript.shadowDamage);
        }

    }
}
