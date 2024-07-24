using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class buySpells : MonoBehaviour
{

    public AudioSource saleSFX;
    public int fireballPrice = 50;
    public int iciclePrice = 50;
    public int necromancyPrice = 250;
    public int dragonPrice = 370;
    public int shadowPrice = 500;
    public int lifeboundPrice = 520;
    public playerCoinsScript playerCoinsScript; //this references to the game logic script for the coins
    public int userCoins;
    public Button fireballButton;
    public GameObject noFundsText;
    public GameObject fireballUI;
    public GameObject lockedFireballUI; //for the store icons
    public GameObject unlockedFireballUI;
    public Boolean fireballSpellUnlocked = false; //this boolean is so in the future you don't need to spend money, logic including re-equipping and not being able to infinitely buy lies on this variable
    public Button icicleButton;
    public GameObject icicleUI; //the main parent for the spell, you activate this thing if you want the spell to work when you press the q & e input
    public GameObject lockedIcicleUI;
    public GameObject unlockedIcicleUI;
    public Boolean icicleSpellUnlocked = false;
    public GameObject necromancyUI;
    public GameObject lockedNecromancyUI;
    public GameObject unlockedNecromancyUI;
    public Boolean necromancySpellUnlocked = false;
    public Button necromancyButton;
    public GameObject dragonUI;
    public GameObject lockedDragonUI;
    public GameObject unlockedDragonUI;
    public Boolean dragonSpellUnlocked = false;
    public Button dragonButton;
    public GameObject shadowUI; //yes this is inside of the utility 1 or 2 parent.
    public GameObject lockedShadowUI;
    public GameObject unlockedShadowUI;
    public Boolean shadowSpellUnlocked = false;
    public Button shadowButton;
    public GameObject lifeboundUI;
    public GameObject lockedLifeboundUI;
    public GameObject unlockedLifeboundUI;
    public Boolean lifeboundSpellUnlocked = false;
    public Button lifeboundButton;


    public void Start() //for future scripts just reference the button listeners for the corresponding spell in the start functions
    {

        if (fireballButton != null) //gets the locked button, this function makes it so that i can also disable the button so i can't just infinitely click the fireball
        {
            fireballButton.onClick.AddListener(fireballBuy);
        }
        else
        {
            Debug.LogError("FireballButton is not assigned.");
        }

        if (icicleButton != null)
        {
            icicleButton.onClick.AddListener(icicleBuy);
        }
        else
        {
            Debug.LogError("icicleButton is not assigned.");
        }
        if (necromancyButton != null)
        {
            necromancyButton.onClick.AddListener(necromancyBuy);
        }
        else
        {
            Debug.LogError("necromancyButton is not assigned.");
        }
        if (dragonButton != null)
        {
            dragonButton.onClick.AddListener(dragonBuy);
        }
        else
        {
            Debug.LogError("dragonButton is not assigned.");
        }
        if (shadowButton != null)
        {
            shadowButton.onClick.AddListener(shadowBuy);
        }
        else
        {
            Debug.LogError("shadowButton is not assigned.");
        }
        if (lifeboundButton != null)
        {
            lifeboundButton.onClick.AddListener(lifeboundBuy);
        }
        else
        {
            Debug.LogError("lifeboundButton is not assigned.");
        }
    }

    public void Update() //constantly updates the user coins
    {
        if (playerCoinsScript != null) //gets player coin
        {
            userCoins = playerCoinsScript.playerCoins;
        }
        else
        {
            Debug.LogError("coinsUiScript is not assigned.");
        }

        if (fireballSpellUnlocked == true) { //change spell icons when the boolean value is true.
            lockedFireballUI.SetActive(false);
            unlockedFireballUI.SetActive(true);
        }
        if (icicleSpellUnlocked == true)
        {
            lockedIcicleUI.SetActive(false);
            unlockedIcicleUI.SetActive(true);
        }
        if (necromancySpellUnlocked == true)
        {
            lockedNecromancyUI.SetActive(false);
            unlockedNecromancyUI.SetActive(true);
        }
        if (dragonSpellUnlocked == true)
        {
            lockedDragonUI.SetActive(false);
            unlockedDragonUI.SetActive(true);
        }
        if (shadowSpellUnlocked == true)
        {
            lockedShadowUI.SetActive(false);
            unlockedShadowUI.SetActive(true);
        }
        if (lifeboundSpellUnlocked == true)
        {
            lockedLifeboundUI.SetActive(false);
            unlockedLifeboundUI.SetActive(true);
        }

    }

    public void fireballBuy() //to continue this script just make it so you just add another button with the public button gameobject function and then create an int variable on the spell price e.g int fireballPrice = 10;
    {
        if (userCoins >= fireballPrice)
        {
            userCoins -= fireballPrice;
            playerCoinsScript.playerCoins = userCoins; // Update the player's coins in the script
            if (fireballUI != null)
            {
                fireballSpellUnlocked = true;
                saleSFX.Play();
                
            }
            else
            {
                Debug.LogError("Fireball object not found.");
            }
        }
        else
        {
            notEnoughFunds();
        }
    }
    public void icicleBuy()
    {
        if (userCoins >= iciclePrice)
        {
            userCoins -= iciclePrice;
            playerCoinsScript.playerCoins = userCoins;
            if (icicleUI != null)
            {
                icicleSpellUnlocked = true;
                saleSFX.Play();
            }
            else
            {
                Debug.LogError("icicle object not found.");
            }
        }
        else
        {
            notEnoughFunds();
        }
    }

    public void necromancyBuy()
    {
        if (userCoins >= necromancyPrice)
        {
            userCoins -= necromancyPrice;
            playerCoinsScript.playerCoins = userCoins;
            if (necromancyUI != null)
            {
                necromancySpellUnlocked = true;
                saleSFX.Play();
            }
            else
            {
                Debug.LogError("necromancy object not found.");
            }
        }
        else
        {
            notEnoughFunds();
        }
    }
    public void dragonBuy()
    {
        if (userCoins >= dragonPrice)
        {
            userCoins -= dragonPrice;
            playerCoinsScript.playerCoins = userCoins;
            if (dragonUI != null)
            {
                dragonSpellUnlocked = true;
                saleSFX.Play();
            }
            else
            {
                Debug.LogError("dragon object not found.");
            }
        }
        else
        {
            notEnoughFunds();
        }
    }
    public void shadowBuy()
    {
        if (userCoins >= shadowPrice)
        {
            userCoins -= shadowPrice;
            playerCoinsScript.playerCoins = userCoins;
            if (shadowUI != null)
            {
                shadowSpellUnlocked = true;
                saleSFX.Play();
            }
            else
            {
                Debug.LogError("shadow object not found.");
            }
        }
        else
        {
            notEnoughFunds();
        }
    }
    public void lifeboundBuy()
    {
        if (userCoins >= lifeboundPrice)
        {
            userCoins -= lifeboundPrice;
            playerCoinsScript.playerCoins = userCoins;
            if (lifeboundUI != null)
            {
                lifeboundSpellUnlocked = true;
                saleSFX.Play();
            }
            else
            {
                Debug.LogError("lifebound object not found.");
            }
        }
        else
        {
            notEnoughFunds();
        }
    }


    void notEnoughFunds() // Display warning text and hide it after a delay
    {
        if (noFundsText != null)
        {
            noFundsText.SetActive(true);
            StartCoroutine(HideNoFundsTextAfterDelay(2f)); // Call coroutine to hide the text after 3 seconds
        }
    }

    IEnumerator HideNoFundsTextAfterDelay(float delay) //i copied this code from chatgpt because the asyncronous time wait functions are confusing for me :-(
    {
        yield return new WaitForSeconds(delay);
        if (noFundsText != null)
        {
            noFundsText.SetActive(false);
        }
    }
}
