using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class healthTextScript : MonoBehaviour
{
    public TMP_Text healthInt;
    public PlayerHealthScript healthScript;

    private void Update()
    {
        healthInt.text = healthScript.playerHealth.ToString() + "/" + healthScript.maxPlayerHealth.ToString();
    }
}
