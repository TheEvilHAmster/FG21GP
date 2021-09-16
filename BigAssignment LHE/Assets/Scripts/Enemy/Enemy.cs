using UnityEngine;
using Random = UnityEngine.Random;


public class Enemy : MonoBehaviour
{

    
    [SerializeField] Transform target;
    [SerializeField] private GameObject explotion, healingBuff;
    [SerializeField] float speed = 2f;
    [SerializeField] private Rigidbody2D rigidBody;
    [SerializeField] private float health = 1f;
    public int score;
    


    void Update()
    {
        // Moves object in direction with transform
        //transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        
        // move object with transform
        if (!(target ==null))
        {
            rigidBody.AddForce((target.position - transform.position) * speed); 
        }
        else
        {
            rigidBody.AddForce((new Vector3(0,0,0) - transform.position) * speed); 
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
        
    }
}
