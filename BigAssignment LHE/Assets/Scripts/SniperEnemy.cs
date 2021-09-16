using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SniperEnemy : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private float speed = 2f;
    [SerializeField] private float distanceFromPlayer = 5f;
    [SerializeField] private float offset = 0;
    [SerializeField] private Rigidbody2D rigidBody;
    [SerializeField] private float health = 2f;
    public int score;
    
    


    void FixedUpdate()
    {

        Vector3 dir = target.position - transform.position;
        float angle = Mathf.Atan2(dir.y,dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle+offset, Vector3.forward);
        
        
        
        if (Vector3.Distance(transform.position, target.position) > distanceFromPlayer)
        {
            rigidBody.AddForce((target.position - transform.position) * speed); 
        }
        else
        {
            rigidBody.AddForce(transform.up * (speed * 1), ForceMode2D.Impulse);
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
