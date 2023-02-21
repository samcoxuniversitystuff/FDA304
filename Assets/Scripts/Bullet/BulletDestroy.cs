using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDestroy : MonoBehaviour
{
    float timer = 0;
    float maxLifetime = 5f;
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Enemy"))
        {
            Destroy(col.gameObject);
            Destroy(this);
        }
    }

    void Start()
    {
        timer = 0;
    }

    void Update()
    {
        print(timer);
        if (timer < maxLifetime)
        {
            timer += (1);
        }
        else
        {
            Destroy(this);
        }
    }
}
