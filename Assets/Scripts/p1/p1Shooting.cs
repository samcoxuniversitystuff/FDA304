using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class p1Shooting : MonoBehaviour
{
    [SerializeField] private Transform gunBarrel;
    [SerializeField] GameObject South;
    [SerializeField] GameObject North;
    [SerializeField] GameObject West;
    [SerializeField] GameObject East;
    Transform originalGunPosition;

    [SerializeField] private GameObject bullet;
    [SerializeField] private float bulletImpact;

    p1Movement _p1movement;
    Vector2 p1Direction;


    // Start is called before the first frame update
    void Start()
    {
        _p1movement = GetComponent<p1Movement>();
        originalGunPosition = gunBarrel;
    }

    // Update is called once per frame
    void Update()
    {
        gunBarrelUpdate();

        if (Input.GetButtonDown("Fire1"))
        {
            BulletCreation();
        }
    }

    void gunBarrelUpdate()
    {
        p1Direction = _p1movement.GetPlayerDirection();
        if (p1Direction.x == 0 && p1Direction.y == -1) // South.
        {
            gunBarrel = South.transform;
        }
        else if (p1Direction.x == 0 && p1Direction.y == -1) // North.
        {
            gunBarrel = North.transform;
        }
        else if (p1Direction.x == 1 && p1Direction.y == 0) // East.
        {
            gunBarrel = East.transform;
        } 
        else if (p1Direction.x == -1 && p1Direction.y == 0) // West.
        {
            gunBarrel = West.transform;
        }
        else
        {
            gunBarrel = originalGunPosition;
        }
    }

    void BulletCreation()
    {
        GameObject projectile = Instantiate(bullet, gunBarrel.position, gunBarrel.rotation);
        Rigidbody2D bulletRb = projectile.GetComponent<Rigidbody2D>();
        bulletRb.AddForce(gunBarrel.up * bulletImpact, ForceMode2D.Impulse);
    }
}
