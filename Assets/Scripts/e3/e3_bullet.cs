using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class e3_bullet : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D other)
    {

        if (other.gameObject.CompareTag("eSpawner"))
        {
            enemySpawner spawner = other.gameObject.GetComponent<enemySpawner>();
            spawner.ReduceHealth(25);
            Destroy(this.gameObject);
        }
        
        else if (!other.gameObject.CompareTag("Enemy3"))
        {
            Destroy(this.gameObject);
        }
    }
}
