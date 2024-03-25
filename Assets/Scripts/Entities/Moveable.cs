using System;
using UnityEngine;

public abstract class Moveable : MonoBehaviour, IDamageable
{
    [SerializeField] protected MovebleData stats;
    [SerializeField] private GameObject deathEffect;

    public Health health;
    protected Weapon weapon;

    protected virtual void Move(float _speed)
    {
        throw new NotImplementedException();
    }

    protected virtual void Move(Vector2 _target)
    {
        throw new NotImplementedException();
    }

    public virtual void Move(Vector2 _direction, Vector2 _target)
    {
        throw new NotImplementedException();
    }

    public virtual void Shoot()
    {
        throw new NotImplementedException();
    }

    public virtual void Die()
    {
        Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

    public void recover(float _amount)
    {
        health.AddHealth(_amount);
    }

    public virtual void GetDamage(float _damage)
    {
        health.DeductHealth(_damage);
        if (health.GetHealth() <= 0)
        {
            Die();
        }
    }
}