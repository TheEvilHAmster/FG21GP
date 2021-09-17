using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FastEnemy : MonoBehaviour
{
    
    [SerializeField] private GameObject explotion, healingBuff;
    [SerializeField] private Transform target;
    [SerializeField] private float speed = 5f;
    [SerializeField] private Rigidbody2D rigidBody;
    [SerializeField] private float dedTimer = 1;
    [SerializeField] private float health = 1f;
    public int score;
    
    


    void FixedUpdate()
    {
        if (!(target ==null))
        {
            rigidBody.AddForce((target.position - transform.position) * speed); 
        }
        else
        {
            rigidBody.AddForce((new Vector3(0,0,0) - transform.position) * speed);         }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
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
        if (!(GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>() ==null))
        {
            target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        }
        else
        {
            target = new RectTransform();
            target.position = new Vector3(0, 0, 0);
        }
        Destroy(gameObject, dedTimer);
    }
}
