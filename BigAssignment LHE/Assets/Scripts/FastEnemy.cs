using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FastEnemy : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private float speed = 5f;
    [SerializeField] private Rigidbody2D rigidBody;
    [SerializeField] private float dedTimer = 1;
    
    
    


    void FixedUpdate()
    {
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
        Destroy(gameObject, dedTimer);
        Debug.Log("fast spawned");
    }
}
