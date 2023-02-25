using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;


public class b1 : MonoBehaviour
{
    private Rigidbody2D _rigidbody2D;
    
    [SerializeField] private float bulletSpeed = 10;

    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();

    }

    private void Update()
    {
        
    }

    private void FixedUpdate()
    {
        _rigidbody2D.velocity = new Vector2(transform.forward.x * bulletSpeed, transform.forward.y * bulletSpeed);
    }
}

// https://answers.unity.com/questions/351420/simple-timer-1.html
