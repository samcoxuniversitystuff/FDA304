using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Serialization;
using Vector2 = System.Numerics.Vector2;


public class b1 : MonoBehaviour
{
    Rigidbody2D _rigidbody2D;
    public Vector3 BulletDirection;
    [SerializeField] float timer = 3f;
    
    [SerializeField] private GameObject explosion;
    [SerializeField] private AudioClip explosionPoint;

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Bullet"))
        {
            Destroy(col.gameObject);
            Destroy(this.gameObject);
            Debug.Log("Bullet destroyed.");
        }
        else if (col.gameObject.CompareTag("Enemy"))
        {
            p1Score playerScore = FindObjectOfType<p1Score>();
            playerScore.AddScore(1);
            Instantiate(explosion, transform.position, quaternion.identity);
            AudioSource.PlayClipAtPoint(explosionPoint, transform.position, 1);
            Destroy(col.gameObject);
            Destroy(this.gameObject);
            Debug.Log("Enemy destroyed.");
        }

    }

    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }
    
    private void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}

// https://answers.unity.com/questions/351420/simple-timer-1.html
