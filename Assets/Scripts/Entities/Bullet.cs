using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float damage, speed;

    private string targetTag;
    private void Update()
    {
        Move();
    }

    public void SetBullet(string _targetTag, float damage, float speed = 10f)
    {
        this.targetTag = _targetTag;
        this.damage = damage;
        this.speed = speed;
    }

    private void Move()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }

    private void Damage(IDamageable damageable)
    {
        if (damageable != null)
        {
            damageable.GetDamage(damage);

            GameManager.GetInstance().scoreManager.IncrementScore();
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.gameObject.CompareTag(targetTag))
        {
            return;
        }
        IDamageable damageable = collision.GetComponent<IDamageable>();
        Damage(damageable);
    }
}
