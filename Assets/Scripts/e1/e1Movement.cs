using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class e1Movement : MonoBehaviour
{
    private Rigidbody2D _rigidbody2D;

    private float waitSpeed = 5f;
    // Start is called before the first frame update
    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(MoveEnemy());
    }

    IEnumerator MoveEnemy()
    {
        yield return new WaitForSeconds(waitSpeed);
    }

    
}
