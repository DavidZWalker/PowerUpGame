using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EnemySpawnerManager : MonoBehaviour, IActivatable
{
    private ISpawner[] _spawners;
    private float _spawnTimer;
    private bool _isActivated = true;

    public float spawnInterval = 2;
    public int maxEntities = 20;

    // Start is called before the first frame update
    void Start()
    {
        _spawners = FindObjectsOfType<MonoBehaviour>().OfType<EnemySpawner>().ToArray();
    }

    // Update is called once per frame
    void Update()
    {
        if (_isActivated)
            foreach (var spawner in _spawners.Where(x => x.IsActivated()))
            {
                if (_spawnTimer >= spawnInterval && GetEnemyCount() < maxEntities)
                {
                    var spawnNumber = GetRandomNumber(0, _spawners.Length - 1);
                    var spawnpoint = _spawners[spawnNumber];
                    spawner.Spawn();
                    _spawnTimer = 0;
                }
                else
                    _spawnTimer += Time.deltaTime;
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
    
    public void Activate()
    {
        _isActivated = true;
    }

    public void Deactivate()
    {
        _isActivated = false;
    }

    public bool IsActivated()
    {
        return _isActivated;
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

    public int GetSpawnerCount()
    {
        return _spawners.Length;
    }
}
