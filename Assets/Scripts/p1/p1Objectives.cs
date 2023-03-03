using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class p1Objectives : MonoBehaviour
{
    private bool _canProceed = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayerCanProceed()
    {
        _canProceed = true;
    }

    public void PlayerCannotProceed()
    {
        _canProceed = false;
    }

    public bool GetCanProceed()
    {
        return _canProceed;
    }
}
