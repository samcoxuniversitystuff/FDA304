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

    [SerializeField] GameObject SpawnPoint1;
    [SerializeField] GameObject SpawnPoint2;
    [SerializeField] GameObject SpawnPoint3;

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

        Vector3 newEnemyPos = new Vector3(transform.position.x, transform.position.y + Random.Range(-maxDistance, maxDistance), transform.position.z);
        SpawnEnemiesInSpawnPoint(SpawnPoint1);
        SpawnEnemiesInSpawnPoint(SpawnPoint2);
        SpawnEnemiesInSpawnPoint(SpawnPoint3);
        Destroy(this.gameObject);
    }

    void SpawnEnemiesInSpawnPoint(GameObject SpawnPoint)
    {
        Instantiate(enemy, SpawnPoint.transform.position, quaternion.identity);
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
