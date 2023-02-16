using UnityEngine;

public class EnemyMovement
{
    private float _moveSpeed;
    private Transform _target;
    private Transform _transform;
    private Enemy _root;
    private EnemyAnimation _animation;

    public EnemyMovement(Enemy root, EnemyAnimation animation)
    {
        _root = root;
        _moveSpeed = root.Data.MovementData.MoveSpeed;
        _transform = root.transform;
        _target = _root.Target;
        _animation = animation;

        LookAtTarget();
    }

    public void Update()
    {
        Move();
    }

    private void LookAtTarget()
    {
        var distance = _target.position - _transform.position;
        var lookRotation = Quaternion.LookRotation(distance);
        _transform.rotation = Quaternion.AngleAxis(lookRotation.eulerAngles.y, Vector3.up);
    }

    private void Move()
    {
        if (_root.CloseEnough)
        {
            _animation.SetMove(false);
            return;
        }

        _animation.SetMove(true);
        var targetPos = new Vector3(_target.position.x, _transform.position.y, _target.position.z);
        _transform.position = Vector3.MoveTowards(_transform.position, targetPos, _moveSpeed * Time.fixedDeltaTime);
    }
}