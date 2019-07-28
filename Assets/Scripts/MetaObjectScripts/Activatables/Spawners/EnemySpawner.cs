using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EnemySpawner : ActivatableBase, ISpawner
{
    public GameObject enemyPrefab;
    
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
}