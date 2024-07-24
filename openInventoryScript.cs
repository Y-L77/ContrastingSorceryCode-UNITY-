using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class openInventoryScript : MonoBehaviour //this script is the child of the main inventory on off button ui
{
    public GameObject inventoryOpened; //reference the opened gui menu for inventory
    bool inventoryEnabled = false;

    void Start()
    {
        gameObject.GetComponent<Button>().onClick.AddListener(OnOffInventory);

    }


    void OnOffInventory()
    {
        inventoryEnabled ^= true;
        inventoryOpened.SetActive(inventoryEnabled);
    }
}
