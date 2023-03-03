using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterTiles : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            p1Lives player1Lives = col.gameObject.GetComponent<p1Lives>();
            player1Lives.SetLives(0);
        }
    }
}
