using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class p1Shooting : MonoBehaviour
{
    [SerializeField] private Transform gunBarrel;

    [SerializeField] private GameObject bullet;

    [SerializeField] private float bulletImpact;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            BulletBirth();
        }
    }

    void BulletBirth()
    {
        GameObject projectile = Instantiate(bullet, gunBarrel.position, gunBarrel.rotation);
        Rigidbody2D bulletRb = projectile.GetComponent<Rigidbody2D>();
        bulletRb.AddForce(gunBarrel.up * bulletImpact, ForceMode2D.Impulse);
    }
}
