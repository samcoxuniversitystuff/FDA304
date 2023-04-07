using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JimNPC : MonoBehaviour
{
    [SerializeField] private Transform[] pathsToFollow;

    [SerializeField] private float walkSpeed;

    private int pathIndex;
    // Start is called before the first frame update
    void Start()
    {
        transform.position = pathsToFollow[pathIndex].transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (pathIndex < pathsToFollow.Length - 1)
        {
            transform.position = Vector2.MoveTowards(transform.position, 
                pathsToFollow[pathIndex]. transform.position, 
                walkSpeed * Time.deltaTime);

            if (transform.position == pathsToFollow[pathIndex].transform.position)
            {
                pathIndex++;
            }


        }
        else if (pathIndex == pathsToFollow.Length - 1)
        {
            pathIndex = 0;
        }
    }
}

// References.
// https://youtu.be/am3IitICcyA
