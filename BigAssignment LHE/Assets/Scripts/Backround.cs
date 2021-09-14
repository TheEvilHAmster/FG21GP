using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Backround : MonoBehaviour
{
    // [SerializeField] private float horizontalSpeed = 0.2f;
    // [SerializeField] private float verticalSpeed = 0.2f;
    [SerializeField] private Transform player;
    //[SerializeField] private Vector3 offset;


    private MeshRenderer re;
    
    private void Start()
    {
        re = GetComponent<MeshRenderer>();
    }

    private void Update()
    {
        
        // Vector2 offset = new Vector2(Time.time * horizontalSpeed, Time.time * verticalSpeed);
        // re.material.mainTextureOffset = offset;
        
        MeshRenderer mr = GetComponent<MeshRenderer>();
        
        Material mat = mr.material;
        Vector2 offset = mat.mainTextureOffset;
        //offset.x += Time.deltaTime / 10f;
        offset = new Vector2(player.position.x/transform.lossyScale.x, player.position.y/transform.lossyScale.y);
        mat.mainTextureOffset = offset;
        
        //transform.position = new Vector3 (player.position.x + offset.x, player.position.y + offset.y, offset.z); // Camera follows the player with specified offset position

    }
}

