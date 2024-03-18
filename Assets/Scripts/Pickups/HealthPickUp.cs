using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickUp : PickUp
{
    [SerializeField] private float healAmount = 10f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        IDamageable damageable;
        damageable = collision.GetComponent<IDamageable>();
        if (collision.CompareTag("Player") && damageable != null)
        {
            damageable.recover(healAmount);
        }
    }
}