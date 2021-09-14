using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    
    [SerializeField] Transform target;
    [SerializeField] float speed = 2f;
    [SerializeField] private Rigidbody2D rigidBody;


    void Update()
    {
        // Moves object in direction with transform
        //transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        
        // move object with transform
        rigidBody.AddForce((target.position - transform.position) * speed); 
        
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        Destroy(gameObject);
    }

    public void Hit()
    {
        Destroy(gameObject);
    }

    private void Awake()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }
}
