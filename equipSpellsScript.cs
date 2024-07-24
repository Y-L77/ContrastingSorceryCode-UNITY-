using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class equipSpellsScript : MonoBehaviour
{
    public buySpells buySpells;
    public Button equipFireballButton;
    public Button equipIcicleButton;
    public Button equipNecromancyButton;
    public GameObject utilityUIQ;
    public GameObject utilityUIE;
    public Button equipDragonButton;
    public Button equipShadowButton;
    public Button equipLifeboundButton;

    public void Start()
    {

        if (equipFireballButton != null)
        {
            equipFireballButton.onClick.AddListener(equipFireball);
        }
        else
        {
            Debug.LogError("equipFireballButton is not assigned.");
        }
        if (equipIcicleButton != null)
        {
            equipIcicleButton.onClick.AddListener(equipIcicle);
        }
        else
        {
            Debug.LogError("equipIcicleButton is not assigned.");
        }
        if (equipNecromancyButton != null)
        {
            equipNecromancyButton.onClick.AddListener(equipNecromancy);
        }
        else
        {
            Debug.LogError("equipNecromancyButton is not assigned.");
        }
        if (equipDragonButton != null)
        {
            equipDragonButton.onClick.AddListener(equipDragon);
        }
        else
        {
            Debug.LogError("equipDragonButton is not assigned.");
        }
        if (equipShadowButton != null)
        {
            equipShadowButton.onClick.AddListener(equipShadow);
        }
        else
        {
            Debug.LogError("equipShadowButton is not assigned.");
        }
        if (equipLifeboundButton != null)
        {
            equipLifeboundButton.onClick.AddListener(equipLifebound);
        }
        else
        {
            Debug.LogError("equipLifeboundButton is not assigned.");
        }

    }

    public void equipFireball()
    {
        foreach (Transform child in utilityUIQ.transform) //sets every other spell inactive
        {
            child.gameObject.SetActive(false);
        }
        buySpells.fireballUI.SetActive(true);
    }
    public void equipIcicle()
    {
        foreach (Transform child in utilityUIE.transform)
        {
            child.gameObject.SetActive(false);
        }
        buySpells.icicleUI.SetActive(true);
    }
    public void equipNecromancy()
    {
        foreach (Transform child in utilityUIE.transform)
        {
            child.gameObject.SetActive(false);
        }
        buySpells.necromancyUI.SetActive(true);
    }
    public void equipDragon()
    {
        foreach (Transform child in utilityUIQ.transform)
        {
            child.gameObject.SetActive(false);
        }
        buySpells.dragonUI.SetActive(true);
    }
    public void equipShadow()
    {
        foreach (Transform child in utilityUIE.transform)
        {
            child.gameObject.SetActive(false);
        }
        buySpells.shadowUI.SetActive(true);
    }
    public void equipLifebound()
    {
        foreach (Transform child in utilityUIQ.transform)
        {
            child.gameObject.SetActive(false);
        }
        buySpells.lifeboundUI.SetActive(true);
    }
}
