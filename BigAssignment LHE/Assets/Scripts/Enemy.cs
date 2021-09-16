using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Enemy : MonoBehaviour
{

    
    [SerializeField] Transform target;
    [SerializeField] float speed = 2f;
    [SerializeField] private Rigidbody2D rigidBody;
    [SerializeField] private float health = 1f;
    public int score;
    


    void Update()
    {
        // Moves object in direction with transform
        //transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        
        // move object with transform
        rigidBody.AddForce((target.position - transform.position) * speed); 
        
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        Hit();
    }

    public void Hit()
    {
        health--;
        if (health <= 0)
        {
            Die();
        }

    }

    void Die()
    {
        PlayerPrefs.SetInt("Score",PlayerPrefs.GetInt("Score")+score);
        Destroy(gameObject);
    }

    private void Awake()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }
}
