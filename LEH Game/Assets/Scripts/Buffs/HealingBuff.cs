using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealingBuff : MonoBehaviour
{
    private Player player;

    private void Awake()
    {
        player = GameObject.FindObjectOfType<Player>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!(player == null))
        {
            if (player.isAlive)
            {

                if (other.CompareTag(player.tag))
                {
                    player.AddHealth(1);
                    Destroy(gameObject);
                }
            }
        }
    }
    
}
