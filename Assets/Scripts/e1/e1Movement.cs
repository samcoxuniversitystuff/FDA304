using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class e1Movement : MonoBehaviour
{
    private Rigidbody2D _rigidbody2D;

    [SerializeField] float maxDistance = 5f;
    [SerializeField] private float enemySpeed = 1f;
    private Vector2 startingPos;
    private p1Movement _p1Movement;
    // Start is called before the first frame update
    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _p1Movement = FindObjectOfType<p1Movement>();
        startingPos = transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        spotPlayer();
    }

    private void spotPlayer()
    {
        float playerDistance = Vector2.Distance(transform.position, _p1Movement.transform.position);
        Debug.Log(playerDistance);
        // Occurs if the player's calculated distance is greater than the allotted distance.
        if (playerDistance > maxDistance)
        {
            _rigidbody2D.velocity = ((_p1Movement.transform.position - transform.position).normalized) * enemySpeed * Time.fixedDeltaTime;
            // _rigidbody2D.MovePosition(Vector2.MoveTowards(transform.position, _p1Movement.transform.position, enemySpeed * Time.deltaTime));
        }
        else if (playerDistance < maxDistance)
        {
            _rigidbody2D.velocity = new Vector2(0, 0);
        }
    }

    void Update()
    {

    }
}

// Resources:
// https://answers.unity.com/questions/1433786/calculate-distance-between-player-on-object.html
// https://answers.unity.com/questions/607100/how-to-make-an-ai-to-follow-the-player-in-2d-c.html