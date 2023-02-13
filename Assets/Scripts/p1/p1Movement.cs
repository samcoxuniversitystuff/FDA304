using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class p1Movement : MonoBehaviour
{
    Rigidbody2D rb2d;

    int movementSpeed = 3;
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        MovePlayerOld();   
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
