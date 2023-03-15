using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameGates : MonoBehaviour
{
    [SerializeField] private GameObject gateTop;
    [SerializeField] private GameObject gateBottom;

    [SerializeField] private string gateKey;
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
            p1Key playerKey = col.gameObject.GetComponent<p1Key>();
            if (playerKey.GetPlayerKey() == gateKey && playerKey.GetHasKey())
            { 
                OpenGate();
            }

        }
    }

    void OpenGate()
    {
        Debug.Log("This should open the gate.");
    }
}
