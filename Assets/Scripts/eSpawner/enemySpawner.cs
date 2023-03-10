using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

public class enemySpawner : MonoBehaviour
{
    [SerializeField] GameObject enemy;
    [SerializeField] private int amountOfEnemies = 11;
    [SerializeField] private float maxDistance = 0.58f;
    
    private SpriteRenderer _spriteRenderer;
    
    [SerializeField] private int eSpawnerHealth = 100;

    // Start is called before the first frame update
    void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
    }


    public void SpawnNewEnemies()
    {
        for (int i = 0; i < amountOfEnemies; i++)
        {
            Vector3 newEnemyPos = new Vector3(transform.position.x, transform.position.y + Random.Range(-maxDistance, maxDistance), transform.position.z);
            Instantiate(enemy, newEnemyPos, quaternion.identity);
        } 
        Destroy(this.gameObject);
    }

    void CheckHealthLevel()
    {
        if (eSpawnerHealth > 75)
        {
            _spriteRenderer.color = Color.white;
        }
        else if (eSpawnerHealth > 50)
        {
            _spriteRenderer.color = Color.black;
        }
        else if (eSpawnerHealth > 25)
        {
            _spriteRenderer.color = Color.blue;
        }
    }

    public void ReduceHealth(int healthToReduce)
    {
        eSpawnerHealth -= healthToReduce;
        CheckHealthLevel();
        if (eSpawnerHealth <= 0)
        {
            SpawnNewEnemies();
        }
    }
    
}
