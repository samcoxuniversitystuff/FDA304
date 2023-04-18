using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

public class enemySpawner : MonoBehaviour
{
    [SerializeField] GameObject enemy;
    [SerializeField] private GameObject enemy2;

    [SerializeField] private bool spawnEnemy2;


    [SerializeField] private int amountOfEnemies = 11;
    [SerializeField] private float maxDistance = 0.58f;

    private SpriteRenderer _spriteRenderer;

    [SerializeField] private int eSpawnerHealth = 100;

    [SerializeField] GameObject SpawnPoint1;
    [SerializeField] GameObject SpawnPoint2;
    [SerializeField] GameObject SpawnPoint3;

    [SerializeField] private AudioClip glassSound;

    private float _timer = 0;
    [SerializeField] private float maximumTimer = 10;

    // Start is called before the first frame update
    void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!spawnEnemy2)
        {
            UpdateTimer();
        }
    }

    void UpdateTimer()
    {
        if (_timer <= maximumTimer)
        {
            _timer += Time.deltaTime;
        }
        else
        {
            float eSpawnerAmount = FindObjectsOfType<enemySpawner>().Length;
            float enemyAmount = FindObjectsOfType<e1Movement>().Length;
            Debug.Log("Amount of enemy spawners: " + eSpawnerAmount + " " + "Amount of enemies: " + enemyAmount);
            if (enemyAmount <= eSpawnerAmount)
            {
                _spriteRenderer.color = Color.blue;
                Invoke("SpawnPatrolEnemy", 1);

            }
            
            _timer = 0;
        }
    }

    void SpawnPatrolEnemy()
    {
        SpawnEnemiesInSpawnPoint(SpawnPoint2);
        CheckHealthLevel();
    }

    public void SpawnNewEnemies()
    {
        AudioSource.PlayClipAtPoint(glassSound, transform.position);
        Vector3 newEnemyPos = new Vector3(transform.position.x, transform.position.y + Random.Range(-maxDistance, maxDistance), transform.position.z);
        SpawnEnemiesInSpawnPoint(SpawnPoint1);
        SpawnEnemiesInSpawnPoint(SpawnPoint2);
        SpawnEnemiesInSpawnPoint(SpawnPoint3);
        Destroy(this.gameObject);
    }

    void SpawnEnemiesInSpawnPoint(GameObject SpawnPoint)
    {
        if (!spawnEnemy2)
        {
            Instantiate(enemy, SpawnPoint.transform.position, quaternion.identity);
        }
        else if (spawnEnemy2)
        {
            Instantiate(enemy2, SpawnPoint.transform.position, quaternion.identity);

        }

    }

    void CheckHealthLevel()
    {
        if (eSpawnerHealth > 75)
        {
            _spriteRenderer.color = Color.white;
        }
        else if (eSpawnerHealth > 50)
        {
            _spriteRenderer.color = Color.cyan;
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
