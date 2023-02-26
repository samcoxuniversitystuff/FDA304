using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using Vector2 = System.Numerics.Vector2;


public class b1 : MonoBehaviour
{
    Rigidbody2D _rigidbody2D;
    public Vector3 BulletDirection;
    [SerializeField] private float bulletSpeed = 20f;
    [SerializeField] private float buffer = 0.5f;
    float _timer = 3f;
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Enemy"))
        {
            Destroy(col.gameObject);
            Destroy(this);
        }
        else if (col.gameObject.CompareTag("Bullet"))
        {
            Destroy(col.gameObject);
            Destroy(this);
            Debug.Log("Bullet destroyed.");
        }
    }

    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        
    }
    
}

// https://answers.unity.com/questions/351420/simple-timer-1.html
