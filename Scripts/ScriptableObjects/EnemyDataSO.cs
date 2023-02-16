using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObject/EnemyData")]
public class EnemyDataSO : ScriptableObject
{
    [SerializeField] private EnemyMovementData _movementData;
    [SerializeField] private EnemyAttackingData _attackingData;
    [SerializeField] private float _maxHealth;
    [SerializeField] private float _moneyPerDeath;

    public float MaxHealth => _maxHealth;
    public float MoneyPerDeath => _moneyPerDeath;
    public EnemyMovementData MovementData => _movementData;
    public EnemyAttackingData AttackingData => _attackingData;
}