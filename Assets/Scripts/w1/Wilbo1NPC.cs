using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wilbo1NPC : MonoBehaviour
{
    [SerializeField] private GameObject speechBubbleObj;
    // Start is called before the first frame update
    void Start()
    {
        speechBubbleObj.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            speechBubbleObj.SetActive(true);
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        speechBubbleObj.SetActive(false);

    }
}
