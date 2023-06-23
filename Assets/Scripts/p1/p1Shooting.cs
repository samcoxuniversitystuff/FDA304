using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
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
    [SerializeField] private GameObject fireCircleArrow;
    [SerializeField] private GameObject fireCirclePivotPoint;
    [SerializeField] private GameObject firePoint;

    [SerializeField] private SpriteRenderer fireCircleSprite;
    [SerializeField] private SpriteRenderer fireCircleArrowSprite;
    [SerializeField] private SpriteRenderer muzzleSprite;

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
    private Vector2 _mousePosition;
    private Vector2 _rightStickPosition;

    public bool canSpawnSword = true;
    private bool _canFire = true;
    [SerializeField] private GameObject swordGo;
    [SerializeField] private GameObject swordSpawnPoint;

    private CinemachineVirtualCamera _cinemachineVirtualCamera;
    private CinemachineBasicMultiChannelPerlin _cinemachineBasicMultiChannelPerlin;

    PauseGame pauseScript;

    private void Awake()
    {
        Controls = new PolyDungeons();
    }

    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        playerCamera = FindObjectOfType<Camera>();
        _p1Movement = FindObjectOfType<p1Movement>();
        _cinemachineVirtualCamera = FindObjectOfType<CinemachineVirtualCamera>();
        _cinemachineBasicMultiChannelPerlin = FindObjectOfType<CinemachineBasicMultiChannelPerlin>();
        pauseScript = FindObjectOfType<PauseGame>();
        muzzleSprite.enabled = false;
    }

    private void Update()
    {
        xDirection = _controllerDirection.ReadValue<Vector2>().x;
        yDirection = _controllerDirection.ReadValue<Vector2>().y;
        _rightStickPosition = rightStick.ReadValue<Vector2>();
        _mousePosition = Input.mousePosition;

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
        if (!pauseScript.GetPauseStatus() && _canFire)
        {
            if (isShooting)
            {
                ShootBullet();
            }
            else if (!isShooting && canSpawnSword)
            {
                SpawnSword();
            }
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
        lookPosition = playerCamera.ScreenToWorldPoint(_mousePosition);
        _fireDirection = lookPosition - _rigidbody2D.position;
        _firingAngle = Mathf.Atan2(_fireDirection.y, _fireDirection.x) * Mathf.Rad2Deg - 90f;
        // Thanks to theChief on Discord for help with the following line:
        fireCirclePivotPoint.transform.rotation = Quaternion.Euler(0, 0, _firingAngle);
    }
    
    void ShootBullet()
    {
        // Shows Player muzzle, then disables it.
        muzzleSprite.enabled = true;
        // _cinemachineBasicMultiChannelPerlin.m_AmplitudeGain = 1;
        StartCoroutine(disableMuzzle());
        AudioSource.PlayClipAtPoint(bulletSound, transform.position);
        GameObject newBullet = Instantiate(bullet, firePoint.transform.position, Quaternion.Euler(0, 0, _firingAngle));
        // GameObject newBullet = ObjWorldPool.ObjInstance.GetBulletWorldObj();
        if (newBullet != null)
        {
            Rigidbody2D bulletRigidbody = newBullet.GetComponent<Rigidbody2D>();
            bulletRigidbody.velocity = _fireDirection * bulletForceAmount;
            newBullet.SetActive(true);
        }


    }

    IEnumerator disableMuzzle()
    {
        yield return new WaitForSeconds(0.1f);
        muzzleSprite.enabled = false;
        // _cinemachineBasicMultiChannelPerlin.m_AmplitudeGain = 0;

    }

    void SpawnSword()
    {
       GameObject newSword = Instantiate(swordGo, swordSpawnPoint.transform.position, Quaternion.Euler(0, 0, _firingAngle));
       newSword.transform.parent = swordSpawnPoint.transform;
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

    public void ModifyFireCircleSpriteVisibility(bool condition)
    {
        fireCircleSprite.enabled = condition;
        fireCircleArrowSprite.enabled = condition;
        _canFire = condition;
    }
}

// References:
// https://docs.unity3d.com/ScriptReference/Quaternion.Euler.html
// https://youtu.be/LNLVOjbrQj4
// https://youtu.be/HmXU4dZbaMw
