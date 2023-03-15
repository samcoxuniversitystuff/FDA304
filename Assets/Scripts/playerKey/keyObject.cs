using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class keyObject : MonoBehaviour
{
    [SerializeField] private string keyCode;
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
            p1Key _p1Key = col.gameObject.GetComponent<p1Key>();
            if (!_p1Key.GetHasKey())
            {
                _p1Key.SetHasKey(true);
                _p1Key.SetPlayerKey(keyCode);
                Debug.Log("The player now has the key " + keyCode);
                Destroy(this.gameObject);
            }
        }
    }
}
