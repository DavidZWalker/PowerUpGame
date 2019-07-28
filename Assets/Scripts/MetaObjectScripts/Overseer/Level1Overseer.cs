using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level1Overseer : MonoBehaviour
{
    private EnemySpawnerManager _spawnerManager;
    private float _levelStartTimer;
    private bool _levelStarted = false;

    public float levelStartDelay = 3f;

    // Start is called before the first frame update
    void Start()
    {
        _spawnerManager = FindObjectOfType<EnemySpawnerManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!_levelStarted)
            DoStart();
    }

    private void DoStart()
    {
        _levelStartTimer += Time.deltaTime;
        if (_levelStartTimer >= levelStartDelay)
        {
            StartLevel();
            _levelStartTimer = 0;
        }
    }

    private void StartLevel()
    {
        _spawnerManager.Activate();
    }
}
