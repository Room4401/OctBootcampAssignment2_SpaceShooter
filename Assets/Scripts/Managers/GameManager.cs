using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;

    [Header("Managers")]
    public ScoreManager scoreManager;
    public UIManager uiManager;

    [Header("Spawner")]
    public EnemySpawner spawner;
    public PickUpSpawner dropItem;

    [Header("For reset")]
    [SerializeField] private GameObject player;

    public UnityEvent OnGameOver;

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
        StartEnemySpawn();
    }

    // Update is called once per frame
    void Update()
    {
        spawner.GetEnemySpawn();
        uiManager.UpdateHealth();
        uiManager.UpdateNukeCount();
    }

    public void GameOver()
    {
        StopAllCoroutines();
        OnGameOver?.Invoke();
    }

    public void ResetGame()
    {
        foreach (Enemy enemy in FindObjectsByType<Enemy>(FindObjectsSortMode.None))
        {
            Destroy(enemy.gameObject);
        }
        foreach (PickUp item in FindObjectsByType<PickUp>(FindObjectsSortMode.None))
        {
            Destroy(item.gameObject);
        }
        foreach (Bullet bullet in FindObjectsByType<Bullet>(FindObjectsSortMode.None))
        {
            Destroy(bullet.gameObject);
        }
        GameObject tempPlayer = Instantiate(player, Vector2.zero, Quaternion.identity);
        uiManager.SetPlayer(tempPlayer);
        scoreManager.ResetScore();
        spawner.SpawnRateReset();
        StartEnemySpawn();
    }

    private void StartEnemySpawn()
    {
        spawner.isEnemySpawning = true;
        StopAllCoroutines();
        StartCoroutine(spawner.SpawnEnemy());
    }
}