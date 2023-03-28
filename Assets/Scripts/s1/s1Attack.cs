using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class s1Attack : MonoBehaviour
{
    [SerializeField] private AudioClip hitSound;

    private p1Shooting _playerShooting;

    private p1Movement _p1Movement;
    // Start is called before the first frame update
    void Start()
    {
        _p1Movement = FindObjectOfType<p1Movement>();
        
        _playerShooting = FindObjectOfType<p1Shooting>();
        _playerShooting.SetCanSpawnSword(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Enemy"))
        {
            p1Score playerScore = FindObjectOfType<p1Score>();
            playerScore.AddScore(1);
            // AudioSource.PlayClipAtPoint(hitSound, transform.position, 1);
            _playerShooting.SetCanSpawnSword(true);
            Destroy(col.gameObject);
            // Destroy(this.gameObject);
        }
        else if (col.gameObject.CompareTag("Enemy2"))
        {
            e2Health _e2Health = col.gameObject.GetComponent<e2Health>();
            _e2Health.reduceHealth(25);
            // AudioSource.PlayClipAtPoint(hitSound, transform.position, 1);
            _playerShooting.SetCanSpawnSword(true);
            // Destroy(this.gameObject);
        }
        else if (col.gameObject.CompareTag("eSpawner"))
        {
            enemySpawner spawner = col.gameObject.GetComponent<enemySpawner>();
            spawner.ReduceHealth(50);
            _playerShooting.SetCanSpawnSword(true);
            // Destroy(this.gameObject);
        }
    }

    public void SwordBegin()
    {
        
    }

    public void SwordEnd()
    {
        _playerShooting.SetCanSpawnSword(true);
        Destroy(this.gameObject);
    }
}
