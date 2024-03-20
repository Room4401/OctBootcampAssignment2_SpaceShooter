using UnityEngine;

public class NukePickUp : PickUp
{
    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<Player>().AddNuke();
            base.OnTriggerEnter2D(collision);
        }
    }
}