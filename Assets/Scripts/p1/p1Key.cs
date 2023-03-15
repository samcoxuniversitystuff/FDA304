using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class p1Key : MonoBehaviour
{
    private string _playerKey;

    private bool _hasKey;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetPlayerKey(string keyToSet)
    {
        _playerKey = keyToSet;
    }

    public string GetPlayerKey()
    {
        return _playerKey;
    }

    public void SetHasKey(bool condition)
    {
        _hasKey = condition;
    }

    public bool GetHasKey()
    {
        return _hasKey;
    }
}
