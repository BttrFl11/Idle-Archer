using System;
using UnityEngine;

public class EnemyAttacking
{
    private Enemy _root;
    private EnemyAnimation _animation;
    private EnemyAttackingData _attackingData;
    private float _startTimeBtwAttacks;
    private float _timeBtwAttacks;

    private bool _isAttacking = false;

    public EnemyAttacking(Enemy root, EnemyAnimation animation)
    {
        _root = root;
        _animation = animation;
        _attackingData = root.Data.AttackingData;

        _startTimeBtwAttacks = 1 / _attackingData.AttackRate;
        _timeBtwAttacks = _startTimeBtwAttacks / 2;
    }

    public void Update()
    {
        if (_root.CloseEnough)
        {
            _timeBtwAttacks -= Time.fixedDeltaTime;

            if (_timeBtwAttacks <= 0 && _isAttacking == false)
                PlayAttackAnimation();
        }
    }

    private void PlayAttackAnimation()
    {
        _isAttacking = true;

        _animation.PlayAttack();
    }

    public void ResetAttack()
    {
        _isAttacking = false;
    }

    public void GiveDamage()
    {
        if (_root.Target.TryGetComponent(out IDamageable damageable))
        {
            damageable.TakeDamage(_attackingData.Damage);
        }

        _timeBtwAttacks = _startTimeBtwAttacks;
    }
}
