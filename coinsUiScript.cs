using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class coinsUiScript : MonoBehaviour
{
    public playerCoinsScript playerCoinsScript;
    public TMP_Text coinInt;

    public void Update()
    {
        coinInt.text = playerCoinsScript.playerCoins.ToString();
    }
}
