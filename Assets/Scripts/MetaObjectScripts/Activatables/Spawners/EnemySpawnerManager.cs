using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EnemySpawnerManager : ActivatableBase
{
    private EnemySpawner[] _spawners;
    private float _spawnTimer;
    private int _spawnedEntities;

    public float spawnInterval = 2;
    public int maxSimultaneousEntities = 20; // how many can be alive at any given time
    public int maxSpawnedEntities = -1; // how many should spawn; negative value => infinite

    // Start is called before the first frame update
    void Start()
    {
        _spawners = GetComponentsInChildren<EnemySpawner>().ToArray();
    }

    // Update is called once per frame
    void Update()
    {
        if (maxSpawnedEntities >= 0 && _spawnedEntities >= maxSpawnedEntities)
            Deactivate();

        if (IsActivated())
        {
            var activeSpawners = _spawners.Where(x => x.IsActivated()).ToArray();
            foreach (var spawner in activeSpawners)
            {
                if (_spawnTimer >= spawnInterval && GetEnemyCount() < maxSimultaneousEntities)
                {
                    var spawnNumber = GetRandomNumber(0, activeSpawners.Length - 1);
                    var spawnpoint = activeSpawners[spawnNumber];
                    spawner.Spawn();
                    _spawnedEntities++;
                    _spawnTimer = 0;
                }
                else
                    _spawnTimer += Time.deltaTime;
            }
        }
    }

    private int GetEnemyCount()
    {
        return FindObjectsOfType<MonoBehaviour>().OfType<IEnemy>().Count();
    }

    private int GetRandomNumber(int min, int max)
    {
        var random = new System.Random();
        return random.Next(min, max + 1);
    }

    public void DeactivateSingleSpawner(int spawnerNumber)
    {
        if (spawnerNumber >= 0 && spawnerNumber < GetSpawnerCount())
            _spawners[spawnerNumber].Deactivate();
    }

    public void ActivateSingleSpawner(int spawnerNumber)
    {
        if (spawnerNumber >= 0 && spawnerNumber < GetSpawnerCount())
            _spawners[spawnerNumber].Activate();
    }

    public override void Activate()
    {
        foreach (var spawner in _spawners)
        {
            spawner.Activate();
        }
    }

    public override void Deactivate()
    {
        foreach (var spawner in _spawners)
        {
            spawner.Deactivate();
        }
    }

    public override bool IsActivated()
    {
        return _spawners.Any(x => x.IsActivated());
    }

    public int GetSpawnerCount()
    {
        return _spawners.Length;
    }
}
