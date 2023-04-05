using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;
using UnityEngine.Serialization;

public class pCamera : MonoBehaviour
{
    private p1Shooting _playerShootingScript;

    [SerializeField] private CinemachineVirtualCamera cinemachineVirtualCamera;

    private Vector2 _mousepos;
    // Start is called before the first frame update
    void Start()
    {
        _playerShootingScript = FindObjectOfType<p1Shooting>();
    }

    // Update is called once per frame
    void Update()
    {
        _mousepos = Input.mousePosition;
        Debug.Log("Mouse position: " + _mousepos);
    }
}
