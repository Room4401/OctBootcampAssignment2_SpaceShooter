using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [Header("Spawn Entities")]
    [SerializeField] private Transform[] spawnPositions;
    [SerializeField] private GameObject[] enemyPrefab;

    [Header("Spawn Variables")]
    [SerializeField] private float enemySpawnRate = 1f;
    [SerializeField] private float difficultyRate = 1f;
    [SerializeField] private int spawnLimit = 50;

    public bool isEnemySpawning;
    private float currentSpawnRate = 0f;
    public void CreateEnemy()
    {
        if (FindObjectsByType<Enemy>(FindObjectsSortMode.None).Length < spawnLimit)
        {
            Instantiate(enemyPrefab[Random.Range(0, enemyPrefab.Length)],
                spawnPositions[Random.Range(0, spawnPositions.Length)].position,
                Quaternion.identity);
        }
    }

    public void SpawnRateReset()
    {
        currentSpawnRate = 0f;
    }

    public void GetEnemySpawn()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            CreateEnemy();
        }
    }

    public IEnumerator SpawnEnemy()
    {
        currentSpawnRate = enemySpawnRate;
        while (isEnemySpawning)
        {
            currentSpawnRate += difficultyRate * Time.deltaTime;
            yield return new WaitForSeconds(1.0f / currentSpawnRate);
            CreateEnemy();
        }
    }
}