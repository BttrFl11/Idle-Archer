using UnityEngine;

public class Enemy : MonoBehaviour, IArcherTarget
{
    [SerializeField] private EnemyDataSO _enemyData;
    [SerializeField] private Transform _hitPoint;
    [SerializeField] private Animator _animator;

    private IEnemyHealth _health;
    private EnemyMovement _movement;
    private EnemyAttacking _attacking;
    private EnemyAnimation _animation;
    private bool _isDead = false;

    private Transform _target;

    public Transform Target => _target;
    public EnemyDataSO Data => _enemyData;
    public IEnemyHealth Health => _health;
    public bool CloseEnough => (transform.position - _target.position).magnitude < Data.MovementData.StopDistance;

    private void Awake()
    {
        _target = FindObjectOfType<Tower>().transform;

        _health = new EnemyHealth(this, Die);
        _animation = new EnemyAnimation(_health, _animator);
        _movement = new EnemyMovement(this, _animation);
        _attacking = new EnemyAttacking(this, _animation);
    }

    private void OnDisable()
    {
        _animation.OnDisable();
    }

    private void FixedUpdate()
    {
        if (_isDead)
            return;

        _movement.Update();
        _attacking.Update();
    }

    private void Die()
    {
        _isDead = true;

        PlayerStats.I.Wallet.Add(Data.MoneyPerDeath);

        Destroy(gameObject, 2);
    }

    public Transform GetHitPoint()
    {
        return _hitPoint;
    }

    // Invokes by unity's animation event
    public void GiveDamage()
    {
        _attacking.GiveDamage();
    }

    // Invokes by unity's animation event
    public void ResetAttack()
    {
        _attacking.ResetAttack();
    }

    public bool IsDead() => _isDead;
}
