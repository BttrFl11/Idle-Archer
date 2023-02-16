using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObject/TowerData")]
public class TowerDataSO : ScriptableObject
{
    [SerializeField] private float _maxHealth;
    [SerializeField] private float _healthRegeneration;

    public float MaxHealth { get => _maxHealth; set => _maxHealth = value; }
    public float HealthRegeneration { get => _healthRegeneration; set => _healthRegeneration = value; }
}