using UnityEngine;

public class HealthPickUp : PickUp
{
    [SerializeField] private float healAmount = 10f;

    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        IDamageable damageable;
        damageable = collision.GetComponent<IDamageable>();
        if (collision.CompareTag("Player") && damageable != null)
        {
            damageable.recover(healAmount);
            base.OnTriggerEnter2D(collision);
        }
    }
}