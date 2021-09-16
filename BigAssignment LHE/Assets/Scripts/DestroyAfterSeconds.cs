using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAfterSeconds : MonoBehaviour
{
    [SerializeField] private float dedTimer= 1f;
    void Start()
    {
        Destroy(gameObject, dedTimer);
    }

}
