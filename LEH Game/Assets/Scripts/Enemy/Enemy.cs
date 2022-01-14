using UnityEngine;
using UnityEngine.SocialPlatforms.GameCenter;
using Random = UnityEngine.Random;


public class Enemy : MonoBehaviour
{

    private Player player;
    [SerializeField] Transform target;
    [SerializeField] private GameObject explotion, healingBuff;
    [SerializeField] float speed = 2f;
    [SerializeField] private Rigidbody2D rigidBodyOfEnemy;
    [SerializeField] private float health = 1f;
    public int score;
    


    void Update()
    {
        // Moves object in direction with transform
        //transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        
        // move object with transform
        if (!(target ==null))
        {
            rigidBodyOfEnemy.AddForce((target.position - transform.position) * speed); 
        }
        else
        {
            rigidBodyOfEnemy.AddForce((new Vector3(0,0,0) - transform.position) * speed); 
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
