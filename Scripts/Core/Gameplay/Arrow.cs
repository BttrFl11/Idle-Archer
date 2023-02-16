using UnityEngine;

public class Arrow : MonoBehaviour, IHeroProjectile
{
    [SerializeField] private float _moveSpeed;

    private Transform _target;
    private Archer _archer;

    public void Init(Archer archer, Transform target)
    {
        _archer = archer;
        _target = target;
    }

    private void FixedUpdate()
    {
        if (_target == null)
            Destroy();

        Move();
    }

    private void Move()
    {
        if (_target == null)
            return;

        transform.position = Vector3.MoveTowards(transform.position, _target.position, _moveSpeed * Time.fixedDeltaTime);
        transform.LookAt(_target);

        if ((transform.position - _target.position).magnitude < 0.1)
            GiveDamage(_target.GetComponentInParent<Enemy>().Health);
    }

    private void Destroy()
    {
        Destroy(gameObject);
    }

    public void GiveDamage(IEnemyHealth enemy)
    {
        enemy.TakeDamage(_archer.Data.Damage);

        Destroy();
    }
}