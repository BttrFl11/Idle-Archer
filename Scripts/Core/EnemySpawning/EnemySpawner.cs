using Assets.Scripts.Core.EnemySpawning;
using System;
using UnityEngine;

public class EnemySpawner
{
    private string _levelDataPath = "Levels/";
    private float _spawnRadius;
    private float _timeBtwSpawns;
    private float _startTimeBtwSpawns;
    private LevelDataSO _spawnListData;
    private int _currentLevel = 1;
    private int _enemiesToSpawn;
    private LevelDataSO[] _levels;

    public EnemySpawner(string levelDataPath, float spawnRadius)
    {
        _levelDataPath = levelDataPath;
        _spawnRadius = spawnRadius;

        _levels = Resources.LoadAll<LevelDataSO>(_levelDataPath);


        UpdateLevel();
    }

    private void UpdateLevel()
    {
        _spawnListData = _levels[_currentLevel - 1];
        _startTimeBtwSpawns = 1 / _spawnListData.SpawnRate;
        _timeBtwSpawns = _startTimeBtwSpawns;
        _enemiesToSpawn = _spawnListData.EnemiesCount;
    }

    private void NextLevel()
    {
        _currentLevel++;
        if (_currentLevel >= _levels.Length)
        {
            Debug.Log("All levels completed!");
            return;
        }

        UpdateLevel();
    }

    public void Update()
    {
        _timeBtwSpawns -= Time.fixedDeltaTime;

        if(_timeBtwSpawns <= 0)
        {
            CreateEnemy(GetEnemyPrefab());

            if(_enemiesToSpawn <= 0)
            {
                NextLevel();
            }
        }
    }

    private Enemy GetEnemyPrefab()
    {
        float rand = UnityEngine.Random.value;

        foreach (var item in _spawnListData.SpawnList)
        {
            if(rand <= item.SpawnChance)
            {
                return item.EnemyPrefab;
            }

            rand -= item.SpawnChance;
        }

        return null;
    }

    private void CreateEnemy(Enemy enemyPrefab)
    {
        _enemiesToSpawn--;
        _timeBtwSpawns = _startTimeBtwSpawns;

        var spawnPos = GetSpawnPosition();
        spawnPos.y = enemyPrefab.transform.position.y;
        EnemyEntityCreator.Create(enemyPrefab, spawnPos, Quaternion.identity);
    }

    private Vector3 GetSpawnPosition()
    {
        var circle = UnityEngine.Random.onUnitSphere;
        return new Vector3(circle.x, 0, circle.y).normalized * _spawnRadius;
    }
}
