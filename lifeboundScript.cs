using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class lifeboundScript : MonoBehaviour
{
    public PlayerHealthScript healthScript;
    public Rigidbody2D player;
    public TMP_Text hpText;
    public double displayRegen;
    void Start()
    {
        //referencing the necessary components
        GameObject gameLogic = GameObject.FindWithTag("gamelogicscripts");
        healthScript = gameLogic.GetComponent<PlayerHealthScript>();
        GameObject playerObject = GameObject.FindWithTag("player");
        player = playerObject.GetComponent<Rigidbody2D>();


        displayRegen = healthScript.maxPlayerHealth / 10;
        healthScript.playerHealth += healthScript.maxPlayerHealth / 10;
        player.velocity = Vector2.up * 10;
    }

    void Update()
    {
        hpText.text = "+ " + displayRegen + " HP!";
    }
}
