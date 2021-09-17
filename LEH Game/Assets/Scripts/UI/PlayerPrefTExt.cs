using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerPrefTExt : MonoBehaviour
{
    
    public new string name;
    

    
    void Update()
    {
        GetComponent<Text>().text = PlayerPrefs.GetInt(name)+ "";
    }
}
