using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class p1Hit : MonoBehaviour
{
    private Rigidbody2D _rb2d;
    
    [SerializeField] private AudioClip hitClip;
    
    private SpriteRenderer _spriteRenderer;
    
    private p1Lives _p1Lives;
    private p1Movement _playerMovement;

    [SerializeField] private Color normalColour;
    [SerializeField] private Color hitColour;

    private bool _canGetHit = true;
    [SerializeField] private float hitTime = 0.5f;
    
    public float pushbackAmount = 6;

    public float pushbackTime;
    // Start is called before the first frame update
    void Start()
    {
        _rb2d = GetComponent<Rigidbody2D>();
        _p1Lives = GetComponent<p1Lives>();
        _playerMovement = GetComponent<p1Movement>();
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
                Rigidbody2D enemyRb = col.gameObject.GetComponent<Rigidbody2D>();
                e1Movement enemy = col.gameObject.GetComponent<e1Movement>();
                if (_canGetHit)
                {
                    // Start of 04/04/2023 code.
                    _canGetHit = false;
                    PushBackBegin(enemyRb, enemy);
                    // End of 04/04/2023 code. 
                    AudioSource.PlayClipAtPoint(hitClip, transform.position);
                    Destroy(col.gameObject);
                    _spriteRenderer.color = hitColour;
                    _p1Lives.DeductLives(1);
                    Invoke("ReturnToNormal", hitTime);
                }
                else if (!_canGetHit)
                {
                    PushBackBegin(enemyRb, enemy);
                }


            }
        
            else if (col.gameObject.CompareTag("Water"))
            {
                DestroyPlayer();
            }

            else if (col.gameObject.CompareTag("Enemy2") && _canGetHit)
            {
                DestroyPlayer();
            }

    }

    void PushBackBegin(Rigidbody2D pushBackRb, e1Movement eMovement)
    {
        if (pushBackRb != null)
        {
            eMovement.SetIsMoving(false);
            Vector2 enemyDistance = (pushBackRb.transform.position - transform.position).normalized * pushbackAmount;
            pushBackRb.velocity = enemyDistance;
            StartCoroutine(PushBackEnd(pushBackRb, eMovement));
        }
    }

    IEnumerator PushBackEnd(Rigidbody2D pushBackRb, e1Movement eMovement)
    {
        yield return new WaitForSeconds(pushbackTime);
        if (pushBackRb != null && eMovement != null)
        {
            eMovement.SetIsMoving(true);
        }
    }

    void ReturnToNormal()
    {
        _spriteRenderer.color = normalColour;
        _canGetHit = true;
    }

    void DestroyPlayer()
    {
        _p1Lives.SetLives(0);
    }
}
// References:
// https://youtu.be/QnsGSCXknUY