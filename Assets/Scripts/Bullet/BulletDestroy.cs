using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDestroy : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Enemy"))
        {
            Destroy(col.gameObject);
            Destroy(gameObject);
        }
    }
}
