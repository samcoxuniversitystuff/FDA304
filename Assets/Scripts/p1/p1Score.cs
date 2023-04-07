using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class p1Score : MonoBehaviour
{
    private int _p1Score = 0;

    private float _currentHighScore;
    // Start is called before the first frame update
    void Start()
    {
        _currentHighScore = PlayerPrefs.GetFloat("hs", 0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddScore(int scoreToAdd)
    {
        _p1Score += scoreToAdd;

        if (_p1Score > _currentHighScore)
        {
            _currentHighScore = _p1Score;
            PlayerPrefs.SetFloat("hs", _currentHighScore);
        }
    }

    public int GetScore()
    {
        return _p1Score;
    }
}
