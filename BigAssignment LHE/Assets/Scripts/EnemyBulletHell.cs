using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletHell : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] float speed = 0.2f;
    [SerializeField] private Rigidbody2D rigidBody;
    [SerializeField] private float distanceFromPlayer = 10f;
    public int score;
    [SerializeField]private float health = 5f;


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
