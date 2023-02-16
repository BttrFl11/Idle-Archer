using System;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObject/ArcherData")]
public class ArcherDataSO : ScriptableObject
{
    [SerializeField] private float _attackSpeed;
    [SerializeField] private float _damage;
    [SerializeField] private float _range;

    public float AttackSpeed 
    { 
        get => _attackSpeed;
        set
        {
            _attackSpeed = value;
            OnAttackSpeedChanged?.Invoke(AttackSpeed);
        }
    }
    public float Damage { get => _damage; set => _damage = value; }
    public float Range { get => _range; set => _range = value; }

    public event Action<float> OnAttackSpeedChanged;
}