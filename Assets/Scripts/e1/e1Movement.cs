using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class e1Movement : MonoBehaviour
{
    private Rigidbody2D _rigidbody2D;

    [SerializeField] float maxDistance = 5f;
    [SerializeField] private float enemySpeed = 1f;
    private Vector2 _startingPos;
    private p1Movement _p1Movement;

    private bool _canShootPlayer;
    
    private Vector2 _enemyMovement;
    [SerializeField] private Animator enemyAnimator;
    // Start is called before the first frame update
    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _p1Movement = FindObjectOfType<p1Movement>();
        _startingPos = transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (_p1Movement != null)
        {
            spotPlayer();
        }
    }

    private void spotPlayer()
    {
        float playerDistance = Vector2.Distance(transform.position, _p1Movement.transform.position);
        if (playerDistance <= maxDistance)
        {
            MoveToPlayer();
        }
    }

    void MoveToPlayer()
    {
        
    }

    void Update()
    {
        UpdateEnemyMovement();
        UpdateEnemyAnimation();
    }

    void UpdateEnemyMovement()
    {
        _enemyMovement = _rigidbody2D.velocity;
        Debug.Log("Enemy velocity:" + _enemyMovement);
    }

    void UpdateEnemyAnimation()
    {
        
    }
}

// Resources:
// https://answers.unity.com/questions/1433786/calculate-distance-between-player-on-object.html
// https://answers.unity.com/questions/607100/how-to-make-an-ai-to-follow-the-player-in-2d-c.html