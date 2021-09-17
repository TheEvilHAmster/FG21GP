using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Backround : MonoBehaviour
{

    [SerializeField] private Transform player;
    private MeshRenderer re;
    
    private void Start()
    {
        re = GetComponent<MeshRenderer>();
    }

    private void Update()
    {

        MeshRenderer mr = GetComponent<MeshRenderer>();
        
        Material mat = mr.material;
        Vector2 offset = mat.mainTextureOffset;
        if (!(player==null))
        {
            offset = new Vector2(player.position.x/transform.lossyScale.x, player.position.y/transform.lossyScale.y);
        }
        mat.mainTextureOffset = offset;
        
    }
}

