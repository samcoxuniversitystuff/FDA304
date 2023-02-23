using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class p1Lives : MonoBehaviour
{
    [SerializeField] private int lives = 3;
    // Start is called bef0ore the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public int GetLives()
    {
        return lives;
    }
}
