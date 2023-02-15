using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class p1Movement : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb2d;

    [SerializeField] Animator _a;
    [SerializeField] float movementSpeed = 3f;
    [SerializeField] Vector2 movementDirection;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateMovementDirection();
        UpdateAnimation();
    }

    void UpdateAnimation()
    {
        _a.SetFloat("Horizontal", movementDirection.x);
        _a.SetFloat("Vertical", movementDirection.y);
        _a.SetFloat("Speed", movementDirection.sqrMagnitude);
    }

    void FixedUpdate()
    {
        MovePlayer();
    }


    void UpdateMovementDirection()
    {
        movementDirection.x = Input.GetAxisRaw("Horizontal");
        movementDirection.y = Input.GetAxisRaw("Vertical");
    }

    void MovePlayer()
    {
        rb2d.MovePosition(rb2d.position + movementDirection * (movementSpeed * Time.fixedDeltaTime));
    }



    void MovePlayerOld()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            rb2d.velocity = new Vector2(0, movementSpeed);
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            rb2d.velocity = new Vector2(0, -movementSpeed);
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            rb2d.velocity = new Vector2(-movementSpeed, 0);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            rb2d.velocity = new Vector2(movementSpeed, 0);
        }

    }
}
