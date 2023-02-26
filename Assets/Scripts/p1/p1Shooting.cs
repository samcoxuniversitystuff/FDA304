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
        ShootBullet();
    }

    private void FixedUpdate()
    {

    }

    void ShootBullet()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject _bulletOBJ = Instantiate(bullet, fireObject.transform.position, fireObject.transform.rotation) as GameObject;
            Rigidbody2D _bulletRB = _bulletOBJ.GetComponent<Rigidbody2D>();
            b1 b1Script = _bulletOBJ.GetComponent<b1>();
        }
    }
}
