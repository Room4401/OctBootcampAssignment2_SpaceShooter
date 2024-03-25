using UnityEngine;

public class PickUpSpawner : MonoBehaviour
{
    [Header("Pick Up")]
    [SerializeField] private GameObject[] pickUpPrefab;

    [Header("Drops Variables")]
    [SerializeField][Range(0, 1)] private float dropRate = 0.5f;
    [SerializeField] private int dropLimit = 20;
    public void SpawnPickUp(Vector2 _position)
    {
        float dropCheck = Random.Range(0f, 1f);
        if (dropRate > dropCheck)
        {
            if (FindObjectsByType<PickUp>(FindObjectsSortMode.None).Length < dropLimit)
            {
                Instantiate(pickUpPrefab[Random.Range(0, pickUpPrefab.Length)], _position, Quaternion.identity);
            }
        }
    }
}