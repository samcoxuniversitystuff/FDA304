using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Serialization;

public class p1Shooting : MonoBehaviour
{
    [SerializeField] private GameObject bullet;
    [SerializeField] private float bulletForceAmount = 10;
    [SerializeField] private GameObject fireObject;
    [SerializeField] private GameObject originalFireObject;

    private p1Movement _p1Movement;
    private Vector2 _p1Direction;
    [SerializeField] private GameObject bNorth;
    [SerializeField] private GameObject bSouth;
    [SerializeField] private GameObject bEast;
    [SerializeField] private GameObject bWest;

    private void Start()
    {
        _p1Movement = FindObjectOfType<p1Movement>();
    }

    private void Update()
    {
        SetShootingDirection();
        ShootBullet();
    }

    private void FixedUpdate()
    {

    }

    void SetShootingDirection()
    {
        _p1Direction = _p1Movement.GetPlayerDirection();
        if (_p1Direction.x == 0 && _p1Direction.y == -1) // South.
        {
            fireObject.transform.position = bSouth.transform.position;
            fireObject.transform.rotation = bSouth.transform.rotation;
        }
        else if (_p1Direction.x == 0 && _p1Direction.y == 1) // North.
        {
            fireObject.transform.position = bNorth.transform.position;
            fireObject.transform.rotation = bNorth.transform.rotation;
        }
        else if (_p1Direction.x == 1 && _p1Direction.y == 0) // East.
        {
            fireObject.transform.position = bEast.transform.position;
            fireObject.transform.rotation = bEast.transform.rotation;
        }
        else if (_p1Direction.x == -1 && _p1Direction.y == 0) // West.
        {
            fireObject.transform.position = bWest.transform.position;
            fireObject.transform.rotation = bWest.transform.rotation;
        }
        else
        {
            fireObject.transform.position = bSouth.transform.position;
            fireObject.transform.rotation = bSouth.transform.rotation;
        }
    }

    void ShootBullet()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject _bulletOBJ = Instantiate(bullet, fireObject.transform.position, fireObject.transform.rotation) as GameObject;
            Rigidbody2D _bulletRB = _bulletOBJ.GetComponent<Rigidbody2D>();
            _bulletRB.AddForce(fireObject.transform.forward * bulletForceAmount , ForceMode2D.Impulse);
            
        }
    }
}
