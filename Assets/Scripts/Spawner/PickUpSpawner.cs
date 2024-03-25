using UnityEngine;

public class PickUpSpawner : MonoBehaviour
{
    [Header("Pick Up")]
    [SerializeField] private GameObject[] pickUpPrefab;

    [Header("Drops Variables")]
    [SerializeField][Range(0, 1)] private float dropRate = 0.5f;
    public void SpawnPickUp(Vector2 _position)
    {
        float dropCheck = Random.Range(0f, 1f);
        if (dropRate > dropCheck)
        {
            Instantiate(pickUpPrefab[Random.Range(0, pickUpPrefab.Length)], _position, Quaternion.identity);
        }
    }
}