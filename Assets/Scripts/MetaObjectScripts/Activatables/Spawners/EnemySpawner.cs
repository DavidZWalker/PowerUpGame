using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EnemySpawner : MonoBehaviour, ISpawner
{
    public GameObject enemyPrefab;

    private bool _isActivated = true;

    public void Activate()
    {
        _isActivated = true;
    }

    public void Deactivate()
    {
        _isActivated = false;
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
                
    }

    public void Spawn()
    {
        if (_isActivated)
            Instantiate(enemyPrefab, transform.position, Quaternion.identity);
    }

    public bool IsActivated()
    {
        return _isActivated;
    }
}