using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //Singleton Implementation

    private static GameManager instance;

    public static int enemyCount;

    [Header("Game Entities")]
    [SerializeField] private Transform[] spawnPositions;
    [SerializeField] private GameObject[] enemyPrefab;

    [Header("Game Variables")]
    [SerializeField] private float enemySpawnRate;

    [Header("Managers")]
    public ScoreManager scoreManager;
    public UIManager uiManager;

    private GameObject tempEnemy;
    private bool isEnemySpawning;

    public static GameManager GetInstance()
    {
        return instance;
    }

    private void SetSingleton()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }
        instance = this;
    }

    private void Awake()
    {
        SetSingleton();
    }
    // Start is called before the first frame update
    void Start()
    {
        enemyCount = 0;
        isEnemySpawning = true;
        StartCoroutine(EnemySpawner());
    }

    // Update is called once per frame
    void Update()
    {
        GetEnemySpawn();
        uiManager.UpdateHealth();
    }

    private void CreateEnemy()
    {
        tempEnemy = Instantiate(enemyPrefab[Random.Range(0, enemyPrefab.Length)]);
        tempEnemy.transform.position = spawnPositions[Random.Range(0, spawnPositions.Length)].position;
        EnemyType tempType = tempEnemy.GetComponent<Enemy>().GetEnemyType();
        switch (tempType)
        {
            case EnemyType.Melee:
                tempEnemy.GetComponent<Melee>().SetMeleeEnemy();
                break;
            case EnemyType.Exploder:
                tempEnemy.GetComponent<Exploder>().SetExploderEnemy();
                break;
            case EnemyType.MachineGun:
                tempEnemy.GetComponent<MachineGun>().SetMachineGunEnemy();
                break;
            case EnemyType.Sniper:
                tempEnemy.GetComponent<Sniper>().SetSniperEnemy();
                break;
        }
    }

    private void GetEnemySpawn()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            CreateEnemy();
        }
    }

    IEnumerator EnemySpawner()
    {
        while (isEnemySpawning)
        {
            yield return new WaitForSeconds(1.0f / enemySpawnRate);
            CreateEnemy();
        }

    }
}
