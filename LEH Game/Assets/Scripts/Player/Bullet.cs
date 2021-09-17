using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float timeBeforeDestroy;
    private void Awake()
    {
        Destroy(gameObject, timeBeforeDestroy);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        
        Enemy enemy = other.collider.GetComponent<Enemy>();
        Destroy(gameObject);
        if (ReferenceEquals(enemy, null)) {
            
            return;
        }
        enemy.Hit();
        
    }
}
