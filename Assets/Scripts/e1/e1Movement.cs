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
    [SerializeField] private Animator enemyAnimator;
    private Vector2 _animationDirection;
    private Vector2 _movementDirection;

    private Transform _player;
    // Start is called before the first frame update
    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _p1Movement = FindObjectOfType<p1Movement>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        MoveToPlayer();
    }


    void MoveToPlayer()
    {
        _movementDirection = Vector2.MoveTowards(transform.position, 
            _p1Movement.transform.position,
            enemySpeed * Time.deltaTime);
        Debug.Log("Movement Direction: " + _movementDirection);
        transform.position = _movementDirection;
        UpdateAnimation();
    }
    
    void UpdateAnimation()
    {
        _animationDirection.x = Mathf.Clamp(_movementDirection.x, -1, 1);
        _animationDirection.y = Mathf.Clamp(_movementDirection.y, -1, 1);
        Debug.Log("Animation Direction: " + _animationDirection);
        enemyAnimator.SetFloat("Horizontal", _movementDirection.x);
        enemyAnimator.SetFloat("Vertical", _movementDirection.y);
        enemyAnimator.SetFloat("Speed", _movementDirection.sqrMagnitude);
    }


    void Update()
    {

    }
}

// Resources:
// https://answers.unity.com/questions/1433786/calculate-distance-between-player-on-object.html
// https://answers.unity.com/questions/607100/how-to-make-an-ai-to-follow-the-player-in-2d-c.html