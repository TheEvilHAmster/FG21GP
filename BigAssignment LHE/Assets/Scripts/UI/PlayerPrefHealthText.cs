using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;

public class PlayerPrefHealthText : MonoBehaviour
{
    [SerializeField] private Player player;
    private string playerHealth;
    

    
    void Update()
    {
        if (!(player == null))
        {
            playerHealth = "0";
        }

        GetComponent<Text>().text = playerHealth;
    }
}
