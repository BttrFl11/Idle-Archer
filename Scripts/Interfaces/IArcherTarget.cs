using UnityEngine;

public interface IArcherTarget
{
    bool IsDead();
    Transform GetHitPoint();
}

