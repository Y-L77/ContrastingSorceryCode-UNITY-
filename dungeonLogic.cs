using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class dungeonLogic : MonoBehaviour
{
    public GameObject openMenu;
    public GameObject dungeonMenu;
    public GameObject dungeonTP1Button;
    public playerCoinsScript coinScript;
    private int floor1Cost = 350;
    public GameObject player;
    public AudioSource notEnoughFunds;

    public void Start()
    {
        gameObject.GetComponent<Button>().onClick.AddListener(DungeonMenu);
        gameObject.GetComponent<Button>().onClick.AddListener(closeDungeonMenu);
        gameObject.GetComponent<Button>().onClick.AddListener(dungeonTP1);
    }

    public void DungeonMenu()
    {
        dungeonMenu.SetActive(true);
    }
    public void closeDungeonMenu()
    {
        dungeonMenu.SetActive(false);
    }
    public void dungeonTP1()
    {
        if(coinScript.playerCoins >= floor1Cost)
        {
            coinScript.playerCoins -= floor1Cost;
            player.transform.position = new Vector3(140, 70, 0);
        }
        else
        {
            notEnoughFunds.Play();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        openMenu.SetActive(true);
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        openMenu.SetActive(false);
    }
}   
