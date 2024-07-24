using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


// README: this script works by getting the tag of the child in the utilityUI_1 image, casts the spell and with the cast method it casts the parameter of the tag to reference another method which will go in depth of how the spell's properties are casted. this is the first gui spell script make a 2nd one later
//go inside of the buySpell script to see how the spell activation works better
public class spellCastingScript_UI1 : MonoBehaviour
{
    public GameObject utilityUI_1;
    public GameObject utilityUI_2;
    public GameObject rightHand;
    private string spellTagQ; // Private instance variable to store the spell tag for the q UI
    private string spellTagE; //var for the e UI
    public PlayerMovement playerMovement;


    void Update()
    {
        GetSpellTagQ(); // Update the spellTag variable
        CastQ(spellTagQ); // Call Cast using the updated spellTag

        GetSpellTagE(); //super duper sigma copy paste by the super sigma overthinking programmer me, yl77
        CastE(spellTagE);
    }

    void GetSpellTagQ()
    {
        // Loop through all children of utilityUI_1
        for (int i = 0; i < utilityUI_1.transform.childCount; i++)
        {
            GameObject childQ = utilityUI_1.transform.GetChild(i).gameObject;

            // Check if the child is active
            if (childQ.activeSelf)
            {
                // Store the spell tag in the instance variable
                spellTagQ = childQ.tag;

                // Break the loop since we found the active child
                return;
            }
        }

        // If no active child was found, set spellTag to an appropriate default or handle accordingly
        spellTagQ = ""; // Example: Set to empty string if no active spell found
    }


    void GetSpellTagE()//copy pasted code for e
    {
        // Loop through all children of utilityUI_1
        for (int i = 0; i < utilityUI_2.transform.childCount; i++)
        {
            GameObject childE = utilityUI_2.transform.GetChild(i).gameObject;

            // Check if the child is active
            if (childE.activeSelf)
            {
                // Store the spell tag in the instance variable
                spellTagE = childE.tag;

                // Break the loop since we found the active child
                return;
            }
        }

        spellTagE = "";
    }

    void CastQ(string spellTag)
    {
        // Check if Q key is pressed to cast spell and if the cooldown period has elapsed
        if (Input.GetKeyDown(KeyCode.Q))
        {
            switch (spellTag)
            {
                case "fireball":
                    if (Time.time >= nextFireballTime) //codition to check if the spell's (fireball in this case) is done reloading
                    {
                        shootFireball();
                        fireballSFX.Play();
                    }
                    else
                    {
                        cooldownWarning();
                    }
                    break;
                case "dragon":
                    if (Time.time >= nextDragonTime)
                    {
                        shootDragon();
                        dragonSFX.Play();
                    }
                    else
                    {
                        cooldownWarning();
                    }
                    break;
                case "lifebound":
                    if (Time.time >= nextLifeboundTime)
                    {
                        shootLifebound();
                    }
                    else
                    {
                        cooldownWarning();
                    }
                    break;
            }
        }
    }

    void CastE(string spellTag)
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            switch (spellTag)
            {
                case "icicle":
                    if (Time.time >= nextIcicleTime) //codition to check if the spell's (fireball in this case) is done reloading
                    {
                        shootIcicle();
                        icicleSFX.Play();
                    }
                    else
                    {
                        cooldownWarning();
                    }
                    break;
                case "necromancy":
                    if(Time.time >= nextNecromancyTime)
                    {
                        shootNecromancy();
                        necromancySFX.Play();
                    }
                    else
                    {
                        cooldownWarning();
                    }
                    break;
                case "shadow":
                    if (Time.time >= nextShadowTime)
                    {
                        shadowDash.Play();
                        shootShadow();
                    }
                    else
                    {
                        cooldownWarning();
                    }
                    break;
            }
        }
    }

    public void cooldownWarning()
    {
        Debug.Log("not reloaded yet");
        //in the future put like a "wait set amount of seconds" ui in the screen
    }


    //create spells like this, make the variables and references down and you can see the arguments you need to instiantiate a speel e.g cooldown, time and damage. then make a method for the action.
    public GameObject fireball;
    public float fireballCooldown; // Cooldown time in seconds
    private float nextFireballTime; // Time when next fireball can be cast
    public float fireballDamage; //damage of fireball to be referenced for enemy ais
    public AudioSource fireballSFX;

    public void shootFireball() //this is the first spell i added, create another method under this method for more spells and functionality
    {
        // Set the next allowable fireball time to current time plus cooldown duration
        nextFireballTime = Time.time + fireballCooldown;

        // Instantiate the fireball at the rightHand's position
        GameObject instantiatedFireball = Instantiate(fireball, rightHand.transform.position, Quaternion.identity);

        Rigidbody2D fireballRigidbody = instantiatedFireball.GetComponent<Rigidbody2D>();

        if (fireballRigidbody != null)
        {
            // Set the velocity of the fireball based on the player's facing direction
            if (playerMovement.facingRight)
            {
                fireballRigidbody.velocity = Vector2.right * 10; // Adjust the speed as needed
            }
            else
            {
                fireballRigidbody.velocity = Vector2.left * 10; // Adjust the speed as needed
            }

            // Destroy the instantiated fireball after 3 seconds
            Destroy(instantiatedFireball, 3f);
        }
        else
        {
            Debug.LogError("Rigidbody2D component not found in instantiated fireball.");
        }
    }
    public float icicleCooldown;
    public float nextIcicleTime;
    public GameObject icicle;
    public float icicleDamage;
    public AudioSource icicleSFX;
    public void shootIcicle()
    {
        nextIcicleTime = Time.time + icicleCooldown;

        if(playerMovement.facingRight)
        {
            Vector3 icicleSpawnPosition = rightHand.transform.position + new Vector3(2, 5, 0);
            Instantiate(icicle, icicleSpawnPosition, Quaternion.identity);
        }
        else
        {
            Vector3 icicleSpawnPosition = rightHand.transform.position + new Vector3(-2, 5, 0);
            Instantiate(icicle, icicleSpawnPosition, Quaternion.identity);
        }
    }

    public float necromancyCooldown;
    public float nextNecromancyTime;
    public float necromancyDamage;
    public GameObject necromancy;
    public AudioSource necromancySFX;

    public void shootNecromancy()
    {
        nextNecromancyTime = Time.time + necromancyCooldown;
        GameObject instiantiatedNecromancy = Instantiate(necromancy, rightHand.transform.position, Quaternion.identity);
        Destroy(instiantiatedNecromancy, 8f);
    }
    public float dragonCooldown;
    public float nextDragonTime;
    public float dragonDamage;
    public GameObject dragon; //this is the prefab
    public AudioSource dragonSFX;

    public void shootDragon()
    {
        nextDragonTime = Time.time + dragonCooldown;
        GameObject instiantiatedDragon = Instantiate(dragon, rightHand.transform.position + new Vector3(0, 5, 0), Quaternion.identity);
        Destroy(instiantiatedDragon, 4f);
    }

    public float shadowCooldown;
    public float nextShadowTime;
    public float shadowDamage;
    public GameObject shadow;
    public AudioSource shadowDash;
    //game sounds inside of the shadow destroy script
    public void shootShadow()
    {
        nextShadowTime = Time.time + shadowCooldown;
        GameObject instiantiatedShadow = Instantiate(shadow, rightHand.transform.position, Quaternion.identity);
        Destroy(instiantiatedShadow, 2f);
    }

    public float lifeboundCooldown;
    public float nextLifeboundTime;
    public GameObject lifebound;
    public AudioSource lifeboundDash;

    public void shootLifebound()
    {
        lifeboundDash.Play();
        nextLifeboundTime = Time.time + lifeboundCooldown;
        GameObject instantiatedLifebound = Instantiate(lifebound, rightHand.transform.position, Quaternion.identity);
        Destroy(instantiatedLifebound, 1.3f);
    }
}