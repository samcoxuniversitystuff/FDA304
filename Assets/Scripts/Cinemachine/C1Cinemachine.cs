using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class C1Cinemachine : MonoBehaviour
{
    private CinemachineVirtualCamera _cinemachineVirtualCamera;

    private p1Movement _p1Movement;
    // Start is called before the first frame update
    void Start()
    {
        _cinemachineVirtualCamera = GetComponent<CinemachineVirtualCamera>();
        _p1Movement = FindObjectOfType<p1Movement>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_p1Movement != null)
        {
            _cinemachineVirtualCamera.Follow = _p1Movement.gameObject.transform;
        }
    }
}
