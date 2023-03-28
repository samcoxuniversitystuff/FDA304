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

    [SerializeField] private GameObject fireCircle;
    [SerializeField] private GameObject fireCirclePivotPoint;
    [SerializeField] private GameObject firePoint;

    public bool isShooting = true;

    [SerializeField] private AudioClip bulletSound;

    public PolyDungeons Controls;
    private InputAction _fire;
    private InputAction _switchWeapon;
    private InputAction _controllerDirection;
    public InputAction rightStick;

    public Camera playerCamera;
    [FormerlySerializedAs("mousePosition")] public Vector2 lookPosition;
    private Vector2 _fireDirection;
    private float _firingAngle;

    public bool canSpawnSword = true;
    [SerializeField] private GameObject swordGo;
    [SerializeField] private GameObject swordSpawnPoint;
    
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
        xDirection = _controllerDirection.ReadValue<Vector2>().x;
        yDirection = _controllerDirection.ReadValue<Vector2>().y;



    }

    private void FixedUpdate()
    { 
        RotateCircle();
    }

    private void OnEnable()
    {
        rightStick.Enable();
        _controllerDirection = Controls.Player.ShootingDirection;
        
        _fire = Controls.Player.Fire;
        _switchWeapon = Controls.Player.SwitchWeapon;
        
        _fire.Enable();
        _switchWeapon.Enable();
        
        _fire.performed += Fire;
        _switchWeapon.performed += SwitchWeapon;
        
    }

    private void OnDisable()
    {
        rightStick.Disable();
        _fire.Disable();
    }



    public void Fire(InputAction.CallbackContext callbackContext)
    {
        if (isShooting)
        {
            ShootBullet();
        }
        else if (!isShooting && canSpawnSword)
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
    
    void RotateCircle()
    {
        lookPosition = playerCamera.ScreenToWorldPoint(Input.mousePosition);
        _fireDirection = lookPosition - _rigidbody2D.position;
        _firingAngle = Mathf.Atan2(_fireDirection.y, _fireDirection.x) * Mathf.Rad2Deg - 90f;
        fireCirclePivotPoint.transform.rotation = Quaternion.Euler(0, 0, _firingAngle);
    }
    
    void ShootBullet()
    {
        AudioSource.PlayClipAtPoint(bulletSound, transform.position);
        GameObject newBullet = Instantiate(bullet, firePoint.transform.position, Quaternion.Euler(0, 0, _firingAngle)) as GameObject;
        Rigidbody2D bulletRigidbody = newBullet.GetComponent<Rigidbody2D>();
        bulletRigidbody.velocity = _fireDirection * bulletForceAmount;

    }

    void SwingSword()
    {
       GameObject newSword = Instantiate(swordGo, swordSpawnPoint.transform.position, Quaternion.Euler(0, 0, _firingAngle)) as GameObject;
       // newSword.transform.parent = swordSpawnPoint.transform;
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

    public void SetCanSpawnSword(bool condition)
    {
        canSpawnSword = condition;
    }
}

// References:
// https://docs.unity3d.com/ScriptReference/Quaternion.Euler.html