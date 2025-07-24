using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Events;

public class EnemySpawner : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private GameObject[] enemyPrefabs;

    [Header("Attributes")]
    [SerializeField] private int baseEnemies = 8;
    [SerializeField] private float enemiesPerSecond = .5f;
    [SerializeField] private float timeBetweenWaves = 5f;
    [SerializeField] private float difficultyFactor = .75f;

    [Header("Events")]
    public static UnityEvent onDestroyEnemy = new UnityEvent();
    

    private int currentWave = 1;
    private float timeSinceLastSpawn;
    private int enemiesAlive;
    private int enemiesLeft;
    private bool isSpawning = false;

    private void Awake()
    {
        onDestroyEnemy.AddListener(enemyDestroyed);
    }

    private void Start() 
    {
        StartCoroutine(startWave());
    }

    private void Update()
    {
        if (!isSpawning) return;

        timeSinceLastSpawn += Time.deltaTime;

        if (timeSinceLastSpawn >= (1f / enemiesPerSecond) && enemiesLeft > 0)
        {
            spawnEnemy();
            enemiesLeft--;
            enemiesAlive++;
            timeSinceLastSpawn = 0f;
        }

        if (enemiesAlive == 0 && enemiesLeft == 0)
        {
            endWave();
        }
    }

    private IEnumerator startWave() 
    {
        yield return new WaitForSeconds(timeBetweenWaves);
        isSpawning = true;
        enemiesLeft = enemiesPerWave();
    }

    private void endWave()
    {
        isSpawning = false;
        timeSinceLastSpawn = 0f;
        currentWave++;
        StartCoroutine(startWave());
    }

    private int enemiesPerWave()
    {
        return Mathf.RoundToInt(baseEnemies * Mathf.Pow(currentWave, difficultyFactor));
    }

    private void spawnEnemy()
    {
        GameObject prefabSpawn = enemyPrefabs[0];
        Instantiate(prefabSpawn, MapManager.main.startPoint.position, Quaternion.identity);
    }

    private void enemyDestroyed()
    {
        enemiesAlive--;
    }
}
