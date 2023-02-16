using System;

public interface IDamageable
{
    public event Action OnDied;

    void TakeDamage(float damage);
}
