using System;
using UnityEngine;

public class EnemyHealth : IEnemyHealth
{
    private float _maxHealth;

    public event Action OnDied;

    public EnemyHealth(Enemy root, Action onDied)
    {
        _maxHealth = root.Data.MaxHealth;

        OnDied += onDied;
    }

    private void Die()
    {
        OnDied?.Invoke();
    }

    public void TakeDamage(float damage)
    {
        _maxHealth -= damage;

        if(_maxHealth <= 0)
        {
            Die();
        }
    }
}
