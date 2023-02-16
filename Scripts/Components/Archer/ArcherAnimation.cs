using UnityEngine;

[System.Serializable]
public class ArcherAnimation
{
    private Animator _animator;

    private readonly string _attackTrigger = "Attack";
    private readonly string _attackSpeed = "AttackSpeed";

    public ArcherAnimation(Archer root, Animator animator)
    {
        _animator = animator;

        root.Data.OnAttackSpeedChanged += UpdateAttackAnimationSpeed;

        UpdateAttackAnimationSpeed(root.Data.AttackSpeed);
    }

    public void PlayAttack()
    {
        _animator.SetTrigger(_attackTrigger);
    }

    private void UpdateAttackAnimationSpeed(float newValue)
    {
        _animator.SetFloat(_attackSpeed, newValue);
    }
}
