using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public bool isAlive = true;
    [SerializeField] float movementSpeed = 5f;
    [SerializeField] Rigidbody2D rigidBody;
    [SerializeField] Camera cam;
    [SerializeField] float offset = 0f;
    [SerializeField] private Transform player;

    public int health = 2;

    private Vector2 movement;
    private Vector2 mousePos;

    
    

    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        
    }

    private void Start()
    {
        PlayerPrefs.SetInt("Score",0);
    }

    private void FixedUpdate()
    {
        
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
   
        
        rigidBody.MovePosition(rigidBody.position + movement * movementSpeed * Time.fixedDeltaTime);

        Vector2 lokDir = mousePos - rigidBody.position;
        float angle = Mathf.Atan2(lokDir.y, lokDir.x) * Mathf.Rad2Deg + offset;
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
        health +=(int) healingAmount;
        PlayerPrefs.SetInt("Health",(int)health);
    }

    void Die()
    {
        PlayerPrefs.SetInt("Health",0);
        isAlive = false;
        gameObject.SetActive(isAlive);

    }

    IEnumerator Blink()
    {
        GetComponent<SpriteRenderer>().color = new Color(1, 0, 0);
        yield return new WaitForSeconds(0.2f);
        GetComponent<SpriteRenderer>().color = new Color(1, 1, 1);
    }

}
