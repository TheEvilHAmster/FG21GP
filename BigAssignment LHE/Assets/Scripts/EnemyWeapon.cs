using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWeapon : MonoBehaviour
{
    [SerializeField] Transform firePoint;
    [SerializeField] GameObject bulletPrefab;

    private float i = 0;
    [SerializeField , Tooltip("Shots per sec")] private float shootingSpeed;
    [SerializeField] float bulletForce = 20f;
    
    void FixedUpdate()
    {

        if (50/shootingSpeed < i)
        {
            Shoot();
        }

        i++;
    }

    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
        i = 0;

    }
}
