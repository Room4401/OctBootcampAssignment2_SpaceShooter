using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;

    [Header("Managers")]
    public ScoreManager scoreManager;
    public UIManager uiManager;

    [Header("Spawner")]
    public EnemySpawner spawner;
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
        spawner.isEnemySpawning = true;
        StartCoroutine(spawner.SpawnEnemy());
    }

    // Update is called once per frame
    void Update()
    {
        spawner.GetEnemySpawn();
        uiManager.UpdateHealth();
        uiManager.UpdateNukeCount();
    }
}
