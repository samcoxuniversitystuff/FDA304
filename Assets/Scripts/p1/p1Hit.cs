using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class p1Hit : MonoBehaviour
{
    [SerializeField] private AudioClip hitClip;
    
    private SpriteRenderer _spriteRenderer;
    
    private p1Lives _p1Lives;

    [SerializeField] private Color normalColour;
    [SerializeField] private Color hitColour;

    private bool _canGetHit = true;
    // Start is called before the first frame update
    void Start()
    {
        _p1Lives = GetComponent<p1Lives>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D col)
    {

            if (col.gameObject.CompareTag("Enemy"))
            { 
                AudioSource.PlayClipAtPoint(hitClip, transform.position);
                Destroy(col.gameObject);
                _spriteRenderer.color = hitColour;
                _p1Lives.DeductLives(1);
                Invoke("ReducePlayerLives", 1);

            }
        
            else if (col.gameObject.CompareTag("Water"))
            {
                DestroyPlayer();
            }

            else if (col.gameObject.CompareTag("Enemy2"))
            {
                DestroyPlayer();
            }

    }

    void ReducePlayerLives()
    {
        _spriteRenderer.color = normalColour;
    }

    void DestroyPlayer()
    {
        _p1Lives.SetLives(0);
    }
}
