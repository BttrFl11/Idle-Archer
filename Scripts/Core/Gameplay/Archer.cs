using System.Collections.Generic;
using UnityEngine;

public class Archer : MonoBehaviour, IShootable
{
    [SerializeField] private LayerMask _enemyLayer;
    [SerializeField] private ArcherDataSO _archerData;
    [SerializeField] private Transform _firePoint;
    [SerializeField] private Arrow _arrowPrefab;
    [SerializeField] private Animator _animator;
    [SerializeField, Range(0, 1)] private float _rotationAcceleration;

    private ArcherAnimation _animation;
    private IArcherTarget _target;
    private Collider[] _targets = new Collider[MAX_ENEMIES_IN_RANGE];
    private bool _canAttack = true;

    private const int MAX_ENEMIES_IN_RANGE = 30;

    public ArcherDataSO Data => _archerData;

    private void OnValidate()
    {
        if (_firePoint == null)
            _firePoint = transform;
    }

    private void Awake()
    {
        _animation = new ArcherAnimation(this, _animator);

        Reload();
    }

    private void FixedUpdate()
    {
        if (_canAttack)
        {
            if (_target == null || _target.IsDead() == true)
                UpdateTarget();

            TryFire();
        }

        LookAtTarget();
    }

    private void LookAtTarget()
    {
        if (_target == null)
            return;

        var distance = _target.GetHitPoint().position - transform.position;
        distance.y = 0;
        var lookRotation = Quaternion.LookRotation(distance);
        transform.rotation = Quaternion.Lerp(transform.rotation, lookRotation, _rotationAcceleration);
    }

    private void UpdateTarget()
    {
        _target = null;

        var enemiesCount = Physics.OverlapSphereNonAlloc(transform.position, _archerData.Range, _targets, _enemyLayer);
        if (enemiesCount == 0)
            return;

        List<IArcherTarget> aliveEnemies = new();
        for (int i = 0; i < enemiesCount; i++)
        {
            IArcherTarget t = _targets[i].GetComponent<IArcherTarget>();
            if (t.IsDead() == false)
                aliveEnemies.Add(t);
        }

        if (aliveEnemies.Count == 0) return;

        IArcherTarget target = aliveEnemies[0];
        foreach (var t in aliveEnemies)
        {
            if ((transform.position - t.GetHitPoint().position).magnitude < (transform.position - target.GetHitPoint().position).magnitude)
                target = t;
        }

        _target = target;
    }

    // Invokes by unity's animation event
    public void Reload()
    {
        _canAttack = true;
    }

    // Invokes by unity's animation event
    public void CreateArrow()
    {
        var arrow = Instantiate(_arrowPrefab, _firePoint.position, Quaternion.identity);
        arrow.Init(this, _target.GetHitPoint());
    }

    private void TryFire()
    {
        if (_target == null)
            return;

        Fire();
    }

    public void Fire()
    {
        _canAttack = false;

        _animation.PlayAttack();
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, Data.Range);
    }
}
