using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class Shooter_ai : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;

    public float bulletForce;
    public float timer = 0f;
    public float fireTime;
    public float bulletLife = 0f;
    public bool needsToSeeEnemy = true;

    RaycastHit2D collisionRay;

    void Start()
    {
        timer = Time.time + fireTime - timer;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (timer <= Time.time && (!needsToSeeEnemy || enemySeen()))
        {
            //fire the projectile
            Shoot();
            timer = Time.time + fireTime;
        }
    }


    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.right * bulletForce, ForceMode2D.Impulse);
        if(bulletLife != 0f)
        {
            Destroy(bullet, bulletLife);
        }
    }

    bool enemySeen()
    {
        collisionRay = Physics2D.Raycast(transform.position, Vector2.right, 100, 1 << LayerMask.NameToLayer("Enemy"));
        return collisionRay.collider != null;
    }
}
