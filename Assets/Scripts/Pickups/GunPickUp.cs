using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunPickUp : PickUp
{
    [SerializeField] private float buffDuration = 3f, buffRate = 0.1f;
    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.GetComponent<Player>().StartBuff(buffDuration, buffRate);
            base.OnTriggerEnter2D(collision);
        }
    }
}
