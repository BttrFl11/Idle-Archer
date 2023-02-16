using UnityEngine;

namespace Assets.Scripts.Core.EnemySpawning
{
    public class EnemyEntityCreator : MonoBehaviour
    {
        public static Enemy Create(Enemy enemyPrefab, Vector3 position, Quaternion rotation)
        {
            var enemy = Instantiate(enemyPrefab, position, rotation);
            return enemy;
        }
    }
}