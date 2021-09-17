using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealingBuff : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!(GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>() == null))
        {


            if (other.gameObject.CompareTag("Player"))
            {
                other.gameObject.GetComponent<Player>().AddHealth(1);
                Destroy(gameObject);
            }
        }
        else
        {
            Destroy(gameObject);
        }
        
    }
}
