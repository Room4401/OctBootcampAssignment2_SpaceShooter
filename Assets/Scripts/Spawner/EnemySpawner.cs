using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [Header("Spawn Entities")]
    [SerializeField] private Transform[] spawnPositions;
    [SerializeField] private GameObject[] enemyPrefab;

    [Header("Spawn Variables")]
    [SerializeField] private float enemySpawnRate = 1f;
    [SerializeField] private int spawnLimit = 50;

    public bool isEnemySpawning;

    public void CreateEnemy()
    {
        if (FindObjectsByType<Enemy>(FindObjectsSortMode.None).Length < spawnLimit)
        {
            Instantiate(enemyPrefab[Random.Range(0, enemyPrefab.Length)],
                spawnPositions[Random.Range(0, spawnPositions.Length)].position,
                Quaternion.identity);
        }
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
        while (isEnemySpawning)
        {
            yield return new WaitForSeconds(1.0f / enemySpawnRate);
            CreateEnemy();
        }
    }
}