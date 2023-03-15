using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameGates : MonoBehaviour
{
    [SerializeField] private GameObject gateTop;
    [SerializeField] private GameObject gateBottom;

    [SerializeField] private string gateKey;

    [SerializeField] private float gateMoveAmount;
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
                playerKey.SetPlayerKey("");
                playerKey.SetHasKey(false);
                Debug.Log("The player's key has been reset.");
            }
            else if (playerKey.GetPlayerKey() != gateKey)
            {
                Debug.Log("Sorry, but the key doesn't match the gate lock.");
            }

        }
    }

    void OpenGate()
    {
        Debug.Log("This should open the gate.");
        gateTop.transform.position += new Vector3(gateTop.transform.position.x, 
            gateTop.transform.position.y + gateMoveAmount, gateTop.transform.position.z);
        gateBottom.transform.position += new Vector3(gateBottom.transform.position.x, 
            gateBottom.transform.position.y - gateMoveAmount, gateBottom.transform.position.z);
    }
}
