using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class s1Attack : MonoBehaviour
{
    [SerializeField] private AudioClip hitSound;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Enemy"))
        {
            p1Score playerScore = FindObjectOfType<p1Score>();
            playerScore.AddScore(1);
            // AudioSource.PlayClipAtPoint(hitSound, transform.position, 1);
            Destroy(col.gameObject);
            Destroy(this.gameObject);
        }
        else if (col.gameObject.CompareTag("Enemy2"))
        {
            e2Health _e2Health = col.gameObject.GetComponent<e2Health>();
            _e2Health.reduceHealth(25);
            // AudioSource.PlayClipAtPoint(hitSound, transform.position, 1);
            Destroy(this.gameObject);
        }
        else if (col.gameObject.CompareTag("eSpawner"))
        {
            enemySpawner spawner = col.gameObject.GetComponent<enemySpawner>();
            spawner.ReduceHealth(50);
            Destroy(this.gameObject);
        }
    }
}
