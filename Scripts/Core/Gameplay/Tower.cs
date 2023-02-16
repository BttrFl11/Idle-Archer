using System;
using UnityEngine;

public class Tower : MonoBehaviour, IHealthRegeneable
{
    [SerializeField] private TowerDataSO _towerData;

    private float _health;
    public float Health
    {
        get => _health;
        private set
        {
            _health = value;

            OnHealthChanged?.Invoke(_health, _towerData.MaxHealth);
        }
    }

    /// <summary>
    /// param1 = current health, param2 = max health
    /// </summary>
    public static event Action<float, float> OnHealthChanged;
    public event Action OnDied;

    private void Start()
    {
        Health = _towerData.MaxHealth;
    }

    private void Die()
    {
        print("game over");
    }

    public void TakeDamage(float damage)
    {
        Health -= damage;
        
        if(_health <= 0)
        {
            Die();
        }
    }

    public void RegenerateHealth()
    {

    }
}