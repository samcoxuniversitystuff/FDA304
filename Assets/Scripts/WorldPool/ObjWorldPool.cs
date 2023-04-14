using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjWorldPool : MonoBehaviour
{
    public static ObjWorldPool ObjInstance;

    private void Awake()
    {
        if (ObjInstance == null)
        {
            ObjInstance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
