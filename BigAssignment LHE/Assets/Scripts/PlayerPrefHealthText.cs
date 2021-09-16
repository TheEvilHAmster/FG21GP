using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerPrefHealthText : MonoBehaviour
{
    public string name;
    [SerializeField] private Player player;
    

    
    void Update()
    {
        GetComponent<Text>().text = player.health.ToString();
    }
}
