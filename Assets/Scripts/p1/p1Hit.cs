using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class p1Hit : MonoBehaviour
{
    private p1Lives _p1Lives;
    // Start is called before the first frame update
    void Start()
    {
        _p1Lives = GetComponent<p1Lives>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Enemy"))
        {
            Destroy(col.gameObject);
            _p1Lives.DeductLives(1);
        }
        
        else if (col.gameObject.CompareTag("Water"))
        {
            _p1Lives.SetLives(0);
        }
    }
}
