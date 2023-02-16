using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObject/Level")]
public class LevelDataSO : ScriptableObject
{
    [SerializeField] private int _enemiesCount;
    [SerializeField] private SpawnListElement[] _spawnList;

    public SpawnListElement[] SpawnList => _spawnList;
    public int EnemiesCount => _enemiesCount;
    public float SpawnRate => (float)_enemiesCount / GameConst.LEVEL_DURATION;

    private void Awake()
    {
        Sort();
    }

    [ContextMenu("Print spawn rate")]
    private void PrintSpawnRate()
    {
        Debug.Log("Spawn rate: " + SpawnRate);
    }

    #region Sort
    [ContextMenu("Sort")]
    private void Sort()
    {
        CalculateDropPercent();

        SpawnListElement temp;
        for (int i = 0; i < _spawnList.Length; i++)
        {
            for (int j = 0; j < _spawnList.Length; j++)
            {
                if (_spawnList[i].SpawnChance > _spawnList[j].SpawnChance)
                {
                    temp = _spawnList[j];
                    _spawnList[j] = _spawnList[i];
                    _spawnList[i] = temp;
                }
            }
        }
    }

    private void CalculateDropPercent()
    {
        float content = 0;
        for (int i = 0; i < _spawnList.Length; i++)
            content += _spawnList[i].Value;

        for (int i = 0; i < _spawnList.Length; i++)
        {
            float percent = _spawnList[i].Value / content;
            _spawnList[i].SpawnChance = percent;
        }
    }
    #endregion
}
