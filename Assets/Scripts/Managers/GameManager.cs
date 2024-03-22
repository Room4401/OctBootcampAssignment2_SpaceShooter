using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;

    public static int enemyCount;

    [Header("Managers")]
    public ScoreManager scoreManager;
    public UIManager uiManager;

    [Header("Spawner")]
    [SerializeField] private EnemySpawner spawner;
    public PickUpSpawner dropItem;

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
        spawner = GetComponentInChildren<EnemySpawner>();
        dropItem = GetComponentInChildren<PickUpSpawner>();
    }
    // Start is called before the first frame update
    void Start()
    {
        enemyCount = 0;
        spawner.isEnemySpawning = true;
        StartCoroutine(spawner.SpawnEnemy());
    }

    // Update is called once per frame
    void Update()
    {
        spawner.GetEnemySpawn();
        uiManager.UpdateHealth();
    }
}
