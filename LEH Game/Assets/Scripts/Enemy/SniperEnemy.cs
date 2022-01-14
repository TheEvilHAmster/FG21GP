using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SniperEnemy : MonoBehaviour
{

    private Player player;
    [SerializeField] private GameObject explotion, healingBuff;
    [SerializeField] private Transform target;
    [SerializeField] private float speed = 2f;
    [SerializeField] private float distanceFromPlayer = 5f;
    [SerializeField] private float offset = 0;
    [SerializeField] private Rigidbody2D rigidBody;
    [SerializeField] private int health = 2;
    public int score;
    
    


    void FixedUpdate()
    {



        if (!(target == null))
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
        if ((int)Random.Range(0,3)==0)
        {
            Instantiate(healingBuff, transform.position, Quaternion.identity);
        }
        Instantiate(explotion, transform.position, Quaternion.identity);
        PlayerPrefs.SetInt("Score",PlayerPrefs.GetInt("Score")+score);
        Destroy(gameObject);
    }
    
    
    private void Awake()
    {
        player = GameObject.FindObjectOfType<Player>();
        target = getTargetOfPlayer(player);
        
    }
    
    private Transform getTargetOfPlayer(Player obj)
    {

        if (obj == null)
        {
            return new RectTransform();
        }

        
        return obj.transform;
    }
    

}
