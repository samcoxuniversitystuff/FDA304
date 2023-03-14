using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;

public class p1Movement : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb2d;

    [FormerlySerializedAs("a")] [FormerlySerializedAs("_a")] [SerializeField] Animator playerAnimator;
    [SerializeField] float movementSpeed = 3f;
    [SerializeField] private float speedMultiplier = 2f;
    [SerializeField] private float rushSpeed;

    [SerializeField] private float originalSpeed;
    [SerializeField] Vector2 movementDirection;

    public Camera gameCam;
    private Vector2 _mousePosition;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        originalSpeed = movementSpeed;
        rushSpeed = movementSpeed * speedMultiplier;
    }

    // Update is called once per frame
    void Update()
    {
        UpdateMovementDirection();
        UpdateAnimation();
        ChoosePlayerSpeed();

    }
    
    void FixedUpdate()
    {
        MovePlayer();
    }

    void ChoosePlayerSpeed()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            movementSpeed = rushSpeed;
        }
        else
        {
            movementSpeed = originalSpeed;
        }
    }


    void UpdateAnimation()
    {
        playerAnimator.SetFloat("Horizontal", movementDirection.x);
        playerAnimator.SetFloat("Vertical", movementDirection.y);
        playerAnimator.SetFloat("Speed", movementDirection.sqrMagnitude);
    }



    void UpdateMovementDirection()
    {
        movementDirection.x = Input.GetAxisRaw("Horizontal");
        movementDirection.y = Input.GetAxisRaw("Vertical");
        movementDirection = movementDirection.normalized;

    }

    void MovePlayer()
    {
        rb2d.MovePosition(rb2d.position + movementDirection * (movementSpeed * Time.fixedDeltaTime));
    }

    public Vector2 GetPlayerDirection()
    {
        return movementDirection;
    }
}
