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

    private Vector2 movement;
    private Vector2 mousePos;

    
    

    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
    }
    
    

    private void FixedUpdate()
    {
        rigidBody.MovePosition(rigidBody.position + movement * movementSpeed * Time.fixedDeltaTime);

        Vector2 lokDir = mousePos - rigidBody.position;
        float angle = Mathf.Atan2(lokDir.y +player.position.y, lokDir.x+ player.position.x) * Mathf.Rad2Deg + offset;
        rigidBody.rotation = angle;
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
