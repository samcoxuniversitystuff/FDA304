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
    private float xDirection;
    private float yDirection;

    [SerializeField] private Transform pUp;
    [SerializeField] private Transform pDown;
    [SerializeField] private Transform pLeft;
    [SerializeField] private Transform pRight;
    private void Start()
    {
        _p1Movement = FindObjectOfType<p1Movement>();
    }

    private void Update()
    {
        xDirection = _p1Movement.GetPlayerDirection().x;
        yDirection = _p1Movement.GetPlayerDirection().y;
        Debug.Log("X = " + xDirection + " " + "Y = " + yDirection);
        ShootBullet();
    }

    private void FixedUpdate()
    {

    }

    Vector2 GetShootingPosition()
    {
        switch (xDirection)
        {
            case 0 when yDirection == -1:
                return pDown.position;
            case 0 when yDirection == 1:
                return pUp.position;
            case 1 when yDirection == 0:
                return pRight.position;
            case -1 when yDirection == 0:
                return pLeft.position;
            default:
                return pDown.position;
        }
    }

    Vector2 GetShootingDirection()
    {
        switch (xDirection)
        {
            case 0 when yDirection == -1:
                return Vector2.down;
            case 0 when yDirection == 1:
                return Vector2.up;
            case 1 when yDirection == 0:
                return Vector2.right;
            case -1 when yDirection == 0:
                return Vector2.left;
            default:
                return Vector2.down;
        }
    }

    void ShootBullet()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject _bulletOBJ = Instantiate(bullet, GetShootingPosition(), quaternion.identity) as GameObject;
            Rigidbody2D _bulletRB = _bulletOBJ.GetComponent<Rigidbody2D>();
            b1 b1Script = _bulletOBJ.GetComponent<b1>();
            _bulletRB.velocity = GetShootingDirection() * bulletForceAmount;
        }
    }
}
