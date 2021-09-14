using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletHell : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] float speed = 0.2f;
    [SerializeField] private Rigidbody2D rigidBody;
    [SerializeField] private float distanceFromPlayer = 10f;
    



    void FixedUpdate()
    {
        if (Vector3.Distance(transform.position, target.position) > distanceFromPlayer)
        {
            rigidBody.AddForce((target.position - transform.position) * speed); 
        }
        else
        {
            rigidBody.AddForce(transform.up * (speed * 2), ForceMode2D.Impulse);
        }
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
        Debug.Log("bullethell spawned");
    }
}
