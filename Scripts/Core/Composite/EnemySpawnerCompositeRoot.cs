using UnityEngine;

namespace Assets.Scripts.Core
{
    public class EnemySpawnerCompositeRoot : CompositeRoot
    {
        [SerializeField] private string _levelDataPath = "Levels/";
        [SerializeField] private float _spawnRadius;

        private EnemySpawner _spawner;

        public override void Compose()
        {
            _spawner = new EnemySpawner(_levelDataPath, _spawnRadius);
        }

        private void FixedUpdate()
        {
            _spawner.Update();
        }

        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, _spawnRadius);
        }
    }
}