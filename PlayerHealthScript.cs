using System.Collections;
using UnityEngine;
using TMPro;

public class PlayerHealthScript : MonoBehaviour
{
    public int maxPlayerHealth = 100;
    public int playerHealth = 100;
    public float regenInterval = 2f; // Time in seconds between health regenerations
    public GameObject player;
    public TMP_Text deathText;
    public playerCoinsScript coinsScript;
    public AudioSource respawnSFX;

    private void Start()
    {
        // Start the health regeneration coroutine
        StartCoroutine(RegenerateHealth());
    }

    private void Update()
    {
       if(playerHealth <= 0)
        {
            player.transform.position = new Vector3(-2, 2, 0);
            coinsScript.playerCoins -= coinsScript.playerCoins / 10;
            playerHealth = maxPlayerHealth;
            deathText.text = "Player Death! -" + coinsScript.playerCoins / 10 + "coins!";
            deathText.gameObject.SetActive(true);
            respawnSFX.Play();
            StartCoroutine(HideEnemyKilledText(1f));
        }
    }

    private IEnumerator RegenerateHealth()
    {
        while (true) // Infinite loop for continuous regeneration
        {
            // Wait for the specified interval
            yield return new WaitForSeconds(regenInterval);

            // Regenerate health
            playerHealth += maxPlayerHealth / 10;

            // Clamp the player's health to ensure it doesn't exceed max health
            playerHealth = Mathf.Clamp(playerHealth, 0, maxPlayerHealth);
        }
    }

    public IEnumerator HideEnemyKilledText(float delay)
    {
        yield return new WaitForSeconds(delay); // Wait for the specified delay
        if (deathText.gameObject.activeSelf) // Only hide if it's currently active
        {
            deathText.text = " "; // Hide the text
        }
        else
        {
            Debug.Log("text is not active");
        }
    }
}
