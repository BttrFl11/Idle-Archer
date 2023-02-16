using System;
using UnityEngine;

public class EnemyAnimation
{
    private Animator _animator;
    private IEnemyHealth _health;

    public EnemyAnimation(IEnemyHealth health, Animator animator)
    {
        _animator = animator;
        _health = health;

        health.OnDied += PlayDeath;
    }

    public void OnDisable()
    {
        _health.OnDied -= PlayDeath;
    }

    private void PlayDeath()
    {
        _animator.SetBool("IsDead", true);
    }

    public void PlayAttack()
    {
        _animator.SetTrigger("Attack");
    }

    public void SetMove(bool isMoving)
    {
        _animator.SetBool("IsMoving", isMoving);
    }
}
