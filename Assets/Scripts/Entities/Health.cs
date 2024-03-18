using System;
using UnityEngine;

public class Health
{
    private float currentHealth, maxHealth, regenRate;

    public Health(float _maxHealth)
    {
        maxHealth = _maxHealth;
        currentHealth = _maxHealth;
        regenRate = 0;
    }

    public Health(float _maxHealth, float _regenRate)
    {
        currentHealth = _maxHealth;
        maxHealth = _maxHealth;
        regenRate = _regenRate;
    }

    public float GetHealth()
    {
        return currentHealth;
    }

    public void SetHealth(float _value)
    {
        if (_value > maxHealth || _value < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(_value), $"Valid range for health is between 0 and {maxHealth}");
        }
        currentHealth = _value;
    }

    public void AddHealth(float _valueToAdd)
    {
        currentHealth = Mathf.Min(maxHealth, currentHealth + _valueToAdd);
    }

    public void DeductHealth(float _valueToDeduct)
    {
        currentHealth = Mathf.Max(0, currentHealth - _valueToDeduct);
    }

    public void RegenHealth()
    {
        if (currentHealth < maxHealth / 2)
        {
            AddHealth(regenRate * Time.deltaTime);
        }
    }
}