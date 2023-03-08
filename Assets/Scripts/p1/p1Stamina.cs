using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class p1Stamina : MonoBehaviour
{
    [SerializeField] private float staminaAmount = 100;

    public bool slowdownEnabled = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (staminaAmount <= 95 & !slowdownEnabled)
        {
            staminaAmount += 5 * Time.deltaTime;
        }
    }
    
}
