using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class p1Score : MonoBehaviour
{
    private int _p1Score = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddScore(int scoreToAdd)
    {
        _p1Score += scoreToAdd;
    }

    public int GetScore()
    {
        return _p1Score;
    }
}
