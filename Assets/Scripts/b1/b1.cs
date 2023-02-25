using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;


public class b1 : MonoBehaviour
{
    Rigidbody2D _rigidbody2D;
    [FormerlySerializedAs("_bulletSpeed")] [SerializeField] private float bulletSpeed = 20f;
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
        }
    }

    void Start()
    {
        _timer = 0;
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        _timer -= Time.deltaTime;

        if (_timer <= 0.0f)
        { 
            KillBullet();       
        }
    }

    void KillBullet()
    {
        Destroy(this);
    }
}

// https://answers.unity.com/questions/351420/simple-timer-1.html
