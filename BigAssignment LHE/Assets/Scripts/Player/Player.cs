using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    
    [SerializeField] float movementSpeed = 5f;
    [SerializeField] Rigidbody2D rigidBody;
    [SerializeField] Camera cam;
    [SerializeField] float offset = 0f;
    [SerializeField] private Transform player;

    public float health = 2f;

    private Vector2 movement;
    private Vector2 mousePos;

    
    

    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
    }

    private void Start()
    {
        PlayerPrefs.SetInt("Score",0);
        PlayerPrefs.SetInt("Health",(int)health);
    }

    private void FixedUpdate()
    {
        rigidBody.MovePosition(rigidBody.position + movement * movementSpeed * Time.fixedDeltaTime);

        Vector2 lokDir = mousePos - rigidBody.position;
        float angle = Mathf.Atan2(lokDir.y +player.position.y, lokDir.x+ player.position.x) * Mathf.Rad2Deg + offset;
        rigidBody.rotation = angle;
    }
    
    private void OnCollisionEnter2D(Collision2D other)
    {
        Hit();
    }

    public void Hit()
    {
        health--;
        PlayerPrefs.SetInt("Health",(int)health);
        Blink();
        if (health <= 0)
        {
            Die();
        }

    }

    public void AddHealth(float healingAmount)
    {
        health += healingAmount;
        PlayerPrefs.SetInt("Health",(int)health);
    }

    void Die()
    {
        PlayerPrefs.SetInt("Health",0);
        Destroy(gameObject);
    }

    IEnumerator Blink()
    {
        GetComponent<SpriteRenderer>().color = new Color(1, 0, 0);
        yield return new WaitForSeconds(0.2f);
        GetComponent<SpriteRenderer>().color = new Color(1, 1, 1);
    }
    private void Buffed(int buffType, float buffTime)
    {

        switch (buffType)
        {
            case 1:
                break;
            case 2:
                break;
            case 3:
                break;
            case 4:
                break;
            case 5:
                break;
            case 6:
                break;
        }


        

    }
    
}
