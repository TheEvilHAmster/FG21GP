using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    
    [SerializeField] private Transform player;
    [SerializeField] private Vector3 offset;
  
    void Update () 
    {
        if (player == null)
        {
            return;
        }
        transform.position = new Vector3 (player.position.x + offset.x, player.position.y + offset.y, offset.z); // Camera follows the player with specified offset position
    }
}
