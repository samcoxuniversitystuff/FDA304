using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Timers;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

public class e3FireBowl : MonoBehaviour
{
    [SerializeField] private Transform shootLocationObj;

    [SerializeField] private GameObject bulletObj;

    [SerializeField] private float bulletSpeed = 1;

    [SerializeField] private float minTimer = 1;
    [SerializeField] private float maxTimer = 3;
    private float timer;

    [SerializeField] private Sprite sprite1; // Normal sprite.
    [SerializeField] private Sprite sprite2; // Firing sprite.
    [SerializeField] private SpriteRenderer shootingSpriteRender;
    
    // Start is called before the first frame update
    void Start()
    {
        timer = Random.Range(minTimer, maxTimer);
    }

    // Update is called once per frame
    void Update()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;
        }
        else
        {
            Fire();
            timer = Random.Range(minTimer, maxTimer);
        }
    }

    public void Fire()
    {
        shootingSpriteRender.sprite = sprite2;
        GameObject newBullet = Instantiate(bulletObj, shootLocationObj.position, quaternion.identity);
        Rigidbody2D bulletRB = newBullet.GetComponent<Rigidbody2D>();
        bulletRB.velocity = Vector2.down * bulletSpeed;
        StartCoroutine(DestroyBullet(newBullet));
    }

    IEnumerator DestroyBullet(GameObject bulletToDestroy)
    {
        yield return new WaitForSeconds(3);

        if (bulletToDestroy != null)
        {
            Destroy(bulletToDestroy);
        }
        
        shootingSpriteRender.sprite = sprite1;
    }
}
