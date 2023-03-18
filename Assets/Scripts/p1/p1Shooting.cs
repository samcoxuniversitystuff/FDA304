using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.InputSystem;

public class p1Shooting : MonoBehaviour
{
    private Rigidbody2D _rigidbody2D;
    
    [SerializeField] private GameObject bullet;
    [SerializeField] private float bulletForceAmount = 10;

    private p1Movement _p1Movement;
    private float xDirection;
    private float yDirection;

    [SerializeField] private Transform pUp;
    [SerializeField] private Transform pDown;
    [SerializeField] private Transform pLeft;
    [SerializeField] private Transform pRight;

    [SerializeField] private Transform pUpLeft;
    [SerializeField] private Transform pUpRight;
    [SerializeField] private Transform pDownLeft;
    [SerializeField] private Transform pDownRight;

    public bool isShooting = true;

    [SerializeField] private AudioClip bulletSound;

    public PolyDungeons Controls;
    private InputAction _fire;
    private InputAction _switchWeapon;
    private InputAction _lookDirection;

    public Camera playerCamera;
    public Vector2 mousePosition;
    
    private void Awake()
    {
        Controls = new PolyDungeons();
    }

    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        playerCamera = FindObjectOfType<Camera>();
        _p1Movement = FindObjectOfType<p1Movement>();
    }

    private void Update()
    {
        xDirection = _lookDirection.ReadValue<Vector2>().x;
        yDirection = _lookDirection.ReadValue<Vector2>().y;

        mousePosition = playerCamera.ScreenToWorldPoint(Input.mousePosition);

    }

    private void FixedUpdate()
    {
        Vector2 fireDirection = mousePosition - _rigidbody2D.position;
        float firingAgle = Mathf.Atan2(fireDirection.y, fireDirection.x) * Mathf.Rad2Deg - 90f;
        Debug.Log("Firing angle: " + firingAgle);
    }

    private void OnEnable()
    {
        _lookDirection = Controls.Player.ShootingDirection;
        
        _fire = Controls.Player.Fire;
        _switchWeapon = Controls.Player.SwitchWeapon;
        
        _fire.Enable();
        _switchWeapon.Enable();
        
        _fire.performed += Fire;
        _switchWeapon.performed += SwitchWeapon;
        
    }

    private void OnDisable()
    {
        _fire.Disable();
    }

    public void Fire(InputAction.CallbackContext callbackContext)
    {
        if (isShooting)
        {
            ShootBullet();
        }
        else if (!isShooting)
        {
            SwingSword();
        }
    }

    public void SwitchWeapon(InputAction.CallbackContext callbackContext)
    {
        if (isShooting)
        {
            isShooting = false;
        }
        else if (!isShooting)
        {
            isShooting = true;
        }
    }
    void ShootBullet()
    {
        AudioSource.PlayClipAtPoint(bulletSound, transform.position);
    }

    void SwingSword()
    {
        
    }

    public bool GetShootingMode()
    {
        if (isShooting)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
