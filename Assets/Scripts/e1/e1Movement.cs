using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class e1Movement : MonoBehaviour
{
    private Rigidbody2D _rigidbody2D;

    [SerializeField] float maxDistance = 5f;
    [SerializeField] private float enemySpeed = 1f;
    
    private p1Movement _p1Movement;
    private Vector2 _enemyMovement;
    [SerializeField] private bool isMoving = true;
    
    [SerializeField] private Animator enemyAnimator;
    private Vector2 _animationDirection;
    private Vector2 _movementDirection;

    private Transform _player;

    private Vector3 _originalEnemyPosition;
    // Start is called before the first frame update
    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _p1Movement = FindObjectOfType<p1Movement>();
        _originalEnemyPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (_p1Movement != null)
        {
            UpdateAnimation();
        }
    }

    void FixedUpdate()
    {
        Vector3 originalEnemyLocationCalculation =
            (_originalEnemyPosition - transform.position).normalized * enemySpeed;
        if (_p1Movement != null && isMoving)
        {
            MoveToPlayer();
        }
        else if (_p1Movement == null && transform.position != originalEnemyLocationCalculation)
        {
            _rigidbody2D.velocity = originalEnemyLocationCalculation;
        }
    }


    void MoveToPlayer()
    {
        /*
        _movementDirection = Vector2.MoveTowards(transform.position, 
            _p1Movement.transform.position,
            enemySpeed * Time.deltaTime);
        Debug.Log("Movement Direction: " + _movementDirection);
        _rigidbody2D.position = _movementDirection;
        */
        _movementDirection =  (_p1Movement.gameObject.transform.position - transform.position ).normalized * enemySpeed;
        // Subtraction theory: https://youtu.be/LNLVOjbrQj4?t=397
        _rigidbody2D.velocity = _movementDirection;
    }
    
    void UpdateAnimation()
    {
        _animationDirection = _p1Movement.GetPlayerDirection();
        // Debug.Log("Animation Direction: " + _animationDirection);
        enemyAnimator.SetFloat("Horizontal", _animationDirection.x);
        enemyAnimator.SetFloat("Vertical", _animationDirection.y);
        enemyAnimator.SetFloat("Speed", _animationDirection.sqrMagnitude);
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Walls"))
        {
            isMoving = false;
            if (transform.position.x <= col.gameObject.transform.position.x)
            {
                _rigidbody2D.AddForce(Vector2.right, ForceMode2D.Impulse);
            }
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Walls"))
        {
            isMoving = true;
        }
    }
}

// Resources:
// https://answers.unity.com/questions/1433786/calculate-distance-between-player-on-object.html
// https://answers.unity.com/questions/607100/how-to-make-an-ai-to-follow-the-player-in-2d-c.html