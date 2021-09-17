using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletHell : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] private GameObject explotion, healingBuff;
    [SerializeField] float speed = 0.2f;
    [SerializeField] private Rigidbody2D rigidBody;
    [SerializeField] private float distanceFromPlayer = 10f;
    public int score;
    [SerializeField]private float health = 5f;


    void FixedUpdate()
    {

        if (!(target == null))
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
        else
        {
            rigidBody.AddForce((new Vector3(0,0,0) - transform.position) * speed);         }

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
        if (Random.Range(0,3)==0)
        {
            Instantiate(healingBuff, transform.position, Quaternion.identity);
        }
        Instantiate(explotion, transform.position, Quaternion.identity);
        PlayerPrefs.SetInt("Score",PlayerPrefs.GetInt("Score")+score);
        Destroy(gameObject);
    }

    private void Awake()
    {
        if (!(GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>() == null))
        {
            target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        }
        else
        {
            target = new RectTransform();
            target.position = new Vector3(0, 0, 0);
        }
        
    }
}
